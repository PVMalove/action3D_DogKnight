using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeID,EnemyStaticData> _enemies;

        public void LoadEnemies()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>("StaticData/Enemy")
                .ToDictionary(x => x.EnemyTypeID, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeID typeID) => 
            _enemies.TryGetValue(typeID, out EnemyStaticData staticData) 
                ? staticData 
                : null;
    }
}