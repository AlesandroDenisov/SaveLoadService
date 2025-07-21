using HomoLudens.Core;
using HomoLudens.Data;
using HomoLudens.Gameplay.Score;
using HomoLudens.Services.PersistentProgress;
using HomoLudens.Services.SaveLoad;
using System;
using System.Collections;
using HomoLudens.Core.Factory;
using UnityEngine;
using YG;
using YG.Insides;

public class YGAsyncSaveLoadService : IAsyncSaveLoadService
{
    private bool _isDataLoaded;

    private readonly IPersistentProgressService _progressService;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IGameFactory _gameFactory;

    public bool IsDataLoaded() => _isDataLoaded;

    public YGAsyncSaveLoadService( IPersistentProgressService progressService
                                 , ICoroutineRunner coroutineRunner
                                 , IGameFactory  gameFactory
                                 )
    {
        _progressService = progressService;
        _coroutineRunner = coroutineRunner;
        _gameFactory =  gameFactory;
    }

    public void LoadProgressOrInitNew(uint waitingTimeSeconds, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(WaitingLoadProgress(waitingTimeSeconds, onLoaded));
    }

    public void LoadProgress()
    {
        if (_isDataLoaded) return;

        YGInsides.LoadProgress();

        _isDataLoaded = true;
    }

    public void SaveProgress()
    {
        foreach (ISavedProgressWriter progressWriter in _gameFactory.ProgressWriters) 
            progressWriter.UpdateProgress(_progressService.Progress);
        
        YG2.saves.Progress = _progressService.Progress;
        YG2.SaveProgress();
    }

    public void ResetProgress()
    {
        YG2.SetDefaultSaves();
        YG2.SaveProgress();
        _progressService.Progress = YG2.saves.Progress;
    }

    private IEnumerator WaitingLoadProgress(uint waitingTimeSeconds, Action onLoaded = null)
    {
        if (YG2.isSDKEnabled)
        {
            onLoaded?.Invoke();
            yield break;
        }

        float elapsedTime = 0f;
        while (!_isDataLoaded && elapsedTime < waitingTimeSeconds)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            LoadProgress();
        }

        if (_isDataLoaded)
        {
            _progressService.Progress = YG2.saves.Progress;
        }
        else
        {
            NewProgress();
        } 
        onLoaded?.Invoke();
    }

    private void NewProgress()
    {
        YG2.SetDefaultSaves();
        YG2.SaveProgress();
        _progressService.Progress = YG2.saves.Progress.DeepCopy();
    }
}
