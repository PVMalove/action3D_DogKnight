using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyAnimator))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private GameObject DeathFX;
        [SerializeField] private AgentMoveToHero _agentMove;
        [SerializeField] private BoxCollider _boxCollider;

        public event Action Happend;

        private void Start() =>
            _enemyHealth.HealthChanged += HealthChanged;

        private void OnDestroy() =>
            _enemyHealth.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (_enemyHealth.Current <= 0)
                Die();
        }

        private void Die()
        {
            _enemyHealth.HealthChanged -= HealthChanged;
            _animator.PlayDeath();
            _agentMove.enabled = false;
            _boxCollider.enabled = false;
            SpawnDeathFX();
            StartCoroutine(DestroyTimer());
            Happend?.Invoke();
        }

        private void SpawnDeathFX() =>
            Instantiate(DeathFX, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}