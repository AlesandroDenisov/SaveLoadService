using System;
using System.Collections;

namespace HomoLudens.Services.SaveLoad
{
    public interface IAsyncSaveLoadService : IService
    {
        bool IsDataLoaded();
        void LoadProgress();
        void SaveProgress();
        void LoadProgressOrInitNew(uint waitingTimeSeconds, Action onLoaded = null);
    }
}
