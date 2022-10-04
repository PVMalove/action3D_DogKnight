using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Enemy;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.EnemySpawners
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        public EnemyTypeID EnemyType;
        public string ID { get; set; }

        private IGameFactory _gameFactory;
        private EnemyDeath _enemyDeath;

        private bool _slain;

        public void Construct(IGameFactory factory) =>
            _gameFactory = factory;

        private void OnDestroy()
        {
            if (_enemyDeath != null)
                _enemyDeath.Happend -= Slay;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearedSpawner.Contains(ID))
                _slain = true;
            else
                Spawn();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            List<string> slainSpawnersList = progress.KillData.ClearedSpawner;

            if (_slain && !slainSpawnersList.Contains(ID))
                slainSpawnersList.Add(ID);
        }

        private void Spawn()
        {
            GameObject enemy = _gameFactory.CreateEnemy(EnemyType, transform);
            _enemyDeath = enemy.GetComponent<EnemyDeath>();
            _enemyDeath.Happend += Slay;
        }

        private void Slay()
        {
            if (_enemyDeath != null)
                _enemyDeath.Happend -= Slay;

            _slain = true;
        }
    }
}