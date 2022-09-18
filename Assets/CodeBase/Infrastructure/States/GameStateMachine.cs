using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitState> _states;
        private IExitState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain,
                    services.Single<IGameFactory>(), 
                    services.Single<IPersistentProgressService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, 
                    services.Single<IPersistentProgressService>(),
                    services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadsState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitState =>
            _states[typeof(TState)] as TState;
    }
}