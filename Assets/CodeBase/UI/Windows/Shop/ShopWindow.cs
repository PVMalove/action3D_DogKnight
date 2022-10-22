using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Windows.Shop
{
    public class ShopWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private RewordedAdItem _adItem;

        public void Construct(IAdsService adsService, IPersistentProgressService progressService)
        {
            base.Construct(progressService);
            _adItem.Construct(adsService, progressService);
        }

        protected override void Initialize()
        {
            _adItem.Initialize();
            RefreshCoinsText();
        }

        protected override void SubscribeUpdates()
        {
            _adItem.Subscribe();
            Progress.WorldData.LootData.Changed += RefreshCoinsText;
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            _adItem.Cleanup();
            Progress.WorldData.LootData.Changed -= RefreshCoinsText;
        }

        private void RefreshCoinsText() =>
            _coinsText.text = Progress.WorldData.LootData.Collected.ToString();
    }
}