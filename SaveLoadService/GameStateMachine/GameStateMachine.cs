using HomoLudens.Core.States;
using HomoLudens.Core.Factory;

namespace HomoLudens.Core.StateMachine
{
    public class GameStateMachine : IStateMachine
    {
        private readonly IStateFactory _stateFactory;
        private IExitableState _activeState;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Enter<TState>() where TState : class, IEnterableState
        {
            IEnterableState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _stateFactory.GetState<TState>();
    }
}
