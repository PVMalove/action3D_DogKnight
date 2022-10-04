using System;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    [Serializable]
    public class EnemySpawnerData
    {
        public string ID;
        public EnemyTypeID EnemyTypeID;
        public Vector3 Position;

        public EnemySpawnerData(string id, EnemyTypeID enemyTypeID, Vector3 position)
        {
            ID = id;
            EnemyTypeID = enemyTypeID;
            Position = position;
        }
    }
}