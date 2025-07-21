namespace HomoLudens.Core.States
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IEnterableState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayload>
    {
        void Enter(TPayload payload);
    }
}
