using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Enemy;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject CreateHero(Vector3 at);
        GameObject CreateHub();
        Task CreateSpawner(Vector3 at, string spawnerID, EnemyTypeID enemyTypeID);
        Task<GameObject> CreateEnemy(EnemyTypeID enemyType, Transform parent);
        Task<LootPiece> CreateLoot();

        void CleanUp();
        Task WarmUp();
    }
}