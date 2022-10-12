using CodeBase.Data;
using CodeBase.Enemy;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Inputs;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(CharacterController))]
    public class HeroAttack : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private CharacterController _characterController;

        private IInputService _input;

        private static int _layerMask;
        private Collider[] _hits = new Collider[3];
        private Stats _stats;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();

            _layerMask = 1 << LayerMask.NameToLayer("Hittable");
        }

        private void Update()
        {
            if (_input.IsAttackButtonDown() && !_animator.IsAttacking) 
                _animator.PlayAttack();
        }

        public void OnAttack()
        {
            PhysicsDebug.DrawDebug(StartPoint() + transform.forward, _stats.DamageRadius, 1.0f);
            for (int i = 0; i < Hit(); ++i)
            {
                _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(_stats.Damage);
            }
        }

        private int Hit() =>
            Physics.OverlapSphereNonAlloc(StartPoint() + transform.forward, _stats.DamageRadius, _hits, _layerMask);

        private Vector3 StartPoint() =>
            new Vector3(transform.position.x, _characterController.center.y / 2, transform.position.z);

        public void LoadProgress(PlayerProgress progress) =>
            _stats = progress.Stats;
    }
}