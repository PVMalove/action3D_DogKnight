using CodeBase.UI.Elements;
using UnityEngine;
using UnityEngine.Assertions;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private RestartButtonView _view;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _view = Object.FindObjectOfType<RestartButtonView>();
            Assert.IsNotNull(_view, "Main menu view not found");
            _view.Play += OnPlay;
        }

        private void OnPlay()
        {
            _stateMachine.Enter<BootstrapState>();
        }

        public void Exit()
        {
            _view.Play -= OnPlay;
        }
    }
}