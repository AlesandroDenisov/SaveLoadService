using System.Collections.Generic;
using System.Numerics;
using HomoLudens.Core.AssetManagement;
using HomoLudens.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Object = UnityEngine.Object;

namespace HomoLudens.Core.Factory
{
    public class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgressWriter> ProgressWriters { get; } = new List<ISavedProgressWriter>();

        private readonly IInstantiator _container;
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgressService _persistentProgressService;
        private GameObject _playerGameObject;
        private const string PlayerPath = "Player"; 
        
        public GameObject PlayerGameObject => _playerGameObject;
        
        public GameFactory( IAssetProvider assets
                          , IPersistentProgressService persistentProgressService
                          , IInstantiator container
                          )
         {
             _assets = assets;
             _persistentProgressService = persistentProgressService;
             _container = container;
         }

        public GameObject CreatePlayer(Vector3 at)
        { 
            _playerGameObject = InstantiateRegistered(PlayerPath, at);
            return _playerGameObject;
        }
        
        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgressWriter progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        public void Cleanup()
         {
             ProgressReaders.Clear();
             ProgressWriters.Clear();
         }

         private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
         {
             GameObject prefab = _assets.Load(path: prefabPath);
             GameObject instance = _container.InstantiatePrefab(prefab, at, Quaternion.identity, null);
             RegisterProgressReaders(instance);

             return instance;
         }

         private void RegisterProgressReaders(GameObject gameObject)
         {
             foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                 Register(progressReader);
         }
    }
}