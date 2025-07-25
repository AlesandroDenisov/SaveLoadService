using HomoLudens.Core.States;

namespace HomoLudens.Core.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IEnterableState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}
