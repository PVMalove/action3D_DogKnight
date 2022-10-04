using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeID, EnemyStaticData> _enemies;
        private Dictionary<string, LevelStaticData> _levels;

        public void Load()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>("StaticData/Enemy")
                .ToDictionary(x => x.EnemyTypeID, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>("StaticData/Levels")
                .ToDictionary(x => x.LevelKey, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeID typeID) =>
            _enemies.TryGetValue(typeID, out EnemyStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
    }
}