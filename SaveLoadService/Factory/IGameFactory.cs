using HomoLudens.Services;
using HomoLudens.Services.Gameplay;
using HomoLudens.Services.PersistentProgress;
using UnityEngine;

namespace HomoLudens.Core.Factory
{
    public interface IGameFactory : IService
    {
        GameObject PlayerGameObject { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgressWriter> ProgressWriters { get; }
        GameObject CreatePlayer(Vector3 at);
        void Cleanup();
    }
}