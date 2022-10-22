using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace CodeBase.Infrastructure.Services.Ads
{
    public class AdsService : IAdsService, IUnityAdsListener
    {
        private const string AndroidGameID = "4985066";
        private const string IOSGameID = "4985067";

        private const string UnityRewardedVideoIdAndroid = "Rewarded_Android";
        private const string UnityRewardedVideoIdIOS = "Rewarded_iOS";

        private string _gameID;
        private string _placemenId;

        private Action _onVideoFinished;
        public event Action RewardedVideoReady;

        public int Reward { get; } = 10;

        public void Initialize()
        {
            SetIdsForCurrentPlatform();

            Advertisement.AddListener(this);
            Advertisement.Initialize(_gameID);
        }

        public void ShowRewardedVideo(Action onVideoFinished)
        {
            _onVideoFinished = onVideoFinished;
            Advertisement.Show(_placemenId);
        }

        public bool IsRewardedVideoReady =>
            Advertisement.IsReady(_placemenId);

        public void OnUnityAdsReady(string placementId)
        {
            Debug.Log($"OnUnityAdsReady {placementId}");

            if (placementId == UnityRewardedVideoIdAndroid)
                RewardedVideoReady?.Invoke();
        }

        public void OnUnityAdsDidError(string message) =>
            Debug.Log($"OnUnityAdsDidError {message}");

        public void OnUnityAdsDidStart(string placementId) =>
            Debug.Log($"OnUnityAdsDidStart {placementId}");

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.LogError($"OnUnityAdsDidFinish {showResult}");
                    break;
                case ShowResult.Skipped:
                    Debug.LogError($"OnUnityAdsDidFinish {showResult}");
                    break;
                case ShowResult.Finished:
                    _onVideoFinished?.Invoke();
                    break;
                default:
                    Debug.LogError($"OnUnityAdsDidFinish {showResult}");
                    break;
                    ;
            }

            _onVideoFinished = null;
        }

        private void SetIdsForCurrentPlatform()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    _gameID = AndroidGameID;
                    _placemenId = UnityRewardedVideoIdAndroid;
                    break;

                case RuntimePlatform.IPhonePlayer:
                    _gameID = IOSGameID;
                    _placemenId = UnityRewardedVideoIdIOS;
                    break;

                case RuntimePlatform.WindowsEditor:
                    _gameID = IOSGameID;
                    _placemenId = UnityRewardedVideoIdIOS;
                    break;

                default:
                    Debug.Log("Unsupported platform for ads");
                    break;
            }
        }
    }
}