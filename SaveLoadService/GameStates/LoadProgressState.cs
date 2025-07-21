using HomoLudens.Core.StateMachine;
using HomoLudens.Services.PersistentProgress;
using HomoLudens.Services.SaveLoad;

namespace HomoLudens.Core.States
{
    public class LoadProgressState : IEnterableState
    {
        private const string MainScene = "MainScene";

        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly IAsyncSaveLoadService _asyncSaveLoadProgress;

        public LoadProgressState( GameStateMachine stateMachine
                                , IPersistentProgressService progressService
                                , IAsyncSaveLoadService asyncSaveLoadProgress
                                )
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _asyncSaveLoadProgress = asyncSaveLoadProgress;
        }
        
        public void Enter()
        {
            _asyncSaveLoadProgress.LoadProgressOrInitNew(5, OnLoadedProgress);
        }

        private void OnLoadedProgress()
        {
            _stateMachine.Enter<MockNextState, string>(MainScene);
        }
    }
}