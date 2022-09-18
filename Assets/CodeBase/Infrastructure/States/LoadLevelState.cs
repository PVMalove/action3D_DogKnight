using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadsState<string>
    {
        private const string StartingPointTeg = "StartingPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string payload)
        {
            _curtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(payload, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void InitGameWorld()
        {
            GameObject hero = _gameFactory.CreateHero(at: GameObject.FindWithTag(StartingPointTeg));

            _gameFactory.CreateHub();

            CameraFollow(hero);
        }

        private void CameraFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        }
    }
}