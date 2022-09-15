using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _asset;

        public GameFactory(IAssets asset)
        {
            _asset = asset;
        }

        public GameObject CreateHero(GameObject at) => 
            _asset.Instantiate(AsserPath.DogHeroPath, at: at.transform.position);

        public void CreateHub() => 
            _asset.Instantiate(AsserPath.HudPath);
    }
}