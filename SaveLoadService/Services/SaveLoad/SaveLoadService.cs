using HomoLudens.Data;
using HomoLudens.Core.Factory;
using HomoLudens.Services.PersistentProgress;
using UnityEngine;

namespace HomoLudens.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
    
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService( IPersistentProgressService progressService)
                              , IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            // update all progress writers, who want to update the player progress
            foreach (ISavedProgressWriter progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }

        public void LoadProgressOrInitNew()
        {
            _progressService.Progress = LoadProgress() ?? NewProgress();
        }

        public void ResetProgress()
        {
            _progressService.Progress = NewProgress();
            SaveProgress();
        }
        
        private PlayerProgress NewProgress()
        {
            var progress =  new PlayerProgress();
            
            //Initial fields...
            
            return progress;
        }
    }
}