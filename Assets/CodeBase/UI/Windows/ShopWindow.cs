using TMPro;
using UnityEngine;

namespace CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        protected override void Initialize() => 
             RefreshCoinsText();

        protected override void SubscribeUpdates() =>
            Progress.WorldData.LootData.Changed += RefreshCoinsText;
        
        protected override void Cleanup()
        {
            base.Cleanup();
            Progress.WorldData.LootData.Changed -= RefreshCoinsText;
        }

        private void RefreshCoinsText() =>
            _coinsText.text = Progress.WorldData.LootData.Collected.ToString();
    }
}