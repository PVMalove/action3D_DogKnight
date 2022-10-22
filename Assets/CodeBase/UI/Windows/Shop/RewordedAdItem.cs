using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.Shop
{
    public class RewordedAdItem : MonoBehaviour
    {
        [SerializeField] private Button _showAdButton;
        [SerializeField] private GameObject[] _adActiveObjects;
        [SerializeField] private GameObject[] _adInactiveObjects;

        private IAdsService _adsService;
        private IPersistentProgressService _progressService;

        public void Construct(IAdsService adsService, IPersistentProgressService progressService)
        {
            _adsService = adsService;
            _progressService = progressService;
        }

        public void Initialize()
        {
            _showAdButton.onClick.AddListener(OnShowAdClicked);

            RefreshAvailableAd();
        }

        public void Subscribe() => 
            _adsService.RewardedVideoReady += RefreshAvailableAd;

        public void Cleanup() => 
            _adsService.RewardedVideoReady -= RefreshAvailableAd;

        private void OnShowAdClicked() => 
            _adsService.ShowRewardedVideo(OnVideoFinished);

        private void OnVideoFinished() =>
            _progressService.Progress.WorldData.LootData.Add(_adsService.Reward);

        private void RefreshAvailableAd()
        {
            bool isVideoReady = _adsService.IsRewardedVideoReady;

            foreach (GameObject adActiveObject in _adActiveObjects) 
                adActiveObject.SetActive(isVideoReady);

            foreach (GameObject adInactiveObject in _adInactiveObjects) 
                adInactiveObject.SetActive(!isVideoReady);
        }
    }
}