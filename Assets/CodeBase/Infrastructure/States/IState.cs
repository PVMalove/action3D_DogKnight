namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitState
    {
        void Enter();
    }

    public interface IPayloadsState<TPayload> : IExitState
    {
        void Enter(TPayload payload);
    }

    public interface IExitState
    {
        void Exit();
    }
}