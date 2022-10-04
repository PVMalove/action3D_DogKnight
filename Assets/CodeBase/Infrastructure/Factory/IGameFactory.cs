using System.Collections.Generic;
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

        GameObject CreateHero(GameObject at);
        GameObject CreateHub();
        void CreateSpawner(Vector3 at, string spawnerID, EnemyTypeID enemyTypeID);
        GameObject CreateEnemy(EnemyTypeID enemyType, Transform parent);
        LootPiece CreateLoot();

        void CleanUp();
    }
}