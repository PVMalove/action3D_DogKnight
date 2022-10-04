using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        [SerializeField] private BoxCollider _collider;

        private void Awake() =>
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();

            Debug.Log("Progress Saved!");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!_collider)
                return;

            Gizmos.color = new Color32(14, 118, 15, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}