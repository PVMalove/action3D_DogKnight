using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using TMPro;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class LootPiece : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private GameObject _coin;
        [SerializeField] private GameObject _pickupFXPrefab;
        [SerializeField] private TextMeshPro _lootText;
        [SerializeField] private GameObject _pickupPopup;

        private WorldData _worldData;
        private Loot _loot;

        private const float DelayBeforeDestroying = 1.5f;

        private string _id;

        private bool _picked;
        private bool _loadedFromProgress;

        public void Construct(WorldData worldData) =>
            _worldData = worldData;

        public void LoadProgress(PlayerProgress progress)
        {
            _id = GetComponent<UniqueID>().ID;

            LootPieceData data = progress.WorldData.LootData.LootPiecesOnScene.Dictionary[_id];
            Initialize(data.Loot);
            transform.position = data.Position.AsUnityVector();

            _loadedFromProgress = true;
        }

        public void Initialize(Loot loot) =>
            _loot = loot;

        private void Start()
        {
            if (!_loadedFromProgress)
                _id = GetComponent<UniqueID>().ID;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_picked)
            {
                _picked = true;
                Pickup();
            }
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (_picked)
                return;

            LootPieceDataDictionary lootPiecesOnScene = progress.WorldData.LootData.LootPiecesOnScene;

            if (!lootPiecesOnScene.Dictionary.ContainsKey(_id))
                lootPiecesOnScene.Dictionary
                    .Add(_id, new LootPieceData(transform.position.AsVectorData(), _loot));
        }

        private void Pickup()
        {
            UpdateWorldData();
            HideCoins();
            PlayPickupFX();
            ShowText();

            Destroy(gameObject, DelayBeforeDestroying);
        }

        private void UpdateWorldData()
        {
            UpdateCollectedLootAmount();
            RemoveLootPieceFromSavedPieces();
        }

        private void UpdateCollectedLootAmount() =>
            _worldData.LootData.Collect(_loot);

        private void RemoveLootPieceFromSavedPieces()
        {
            LootPieceDataDictionary savedLootPieces = _worldData.LootData.LootPiecesOnScene;

            if (savedLootPieces.Dictionary.ContainsKey(_id))
                savedLootPieces.Dictionary.Remove(_id);
        }

        private void HideCoins() =>
            _coin.SetActive(false);

        private void PlayPickupFX() =>
            Instantiate(_pickupFXPrefab, transform.position, Quaternion.identity);

        private void ShowText()
        {
            _lootText.text = $"{_loot.Value}";
            _pickupPopup.SetActive(true);
        }
    }
}