using System;

namespace CodeBase.Infrastructure
{
    public interface IState : IExitState
    {
        void Enter();
        
    }

    public interface IPayloadedState<TPayload> : IExitState
    {
        void Enter(TPayload payload);
    }
    
    public interface IExitState
    {
        void Exit();
    }
}
