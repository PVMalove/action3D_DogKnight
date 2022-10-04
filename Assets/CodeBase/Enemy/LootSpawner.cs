using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _enemyDeath;

        private IGameFactory _gameFactory;
        private IRandomService _randomService;

        private int _lootMin;
        private int _lootMax;

        public void Construct(IGameFactory factory, IRandomService random)
        {
            _gameFactory = factory;
            _randomService = random;
        }

        private void Start()
        {
            _enemyDeath.Happend += SpawnLoot;
        }

        public void SetLoot(int min, int max)
        {
            _lootMin = min;
            _lootMax = max;
        }

        private void SpawnLoot()
        {
            _enemyDeath.Happend -= SpawnLoot;

            LootPiece lootPiece = _gameFactory.CreateLoot();
            lootPiece.transform.position = transform.position;
            lootPiece.GetComponent<UniqueID>().GenerateId();

            Loot loot = GenerateLoot();
            lootPiece.Initialize(loot);
        }

        private Loot GenerateLoot()
        {
            return new Loot
            {
                Value = _randomService.Next(_lootMin, _lootMax)
            };
        }
    }
}