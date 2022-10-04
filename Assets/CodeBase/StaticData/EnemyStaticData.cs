using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeID EnemyTypeID;

        [Range(1, 100)] public int Hp = 50;
        [Range(1f, 30f)] public float Damage = 10f;

        public int MinLoot;
        public int MaxLoot;

        [Range(0.5f, 1f)] public float EffectiveDistance = 0.5f;
        [Range(0.5f, 1f)] public float Cleavage = 0.5f;

        [Range(0, 10)] public float MoveSpeed = 3f;

        public GameObject Prefab;
    }
}