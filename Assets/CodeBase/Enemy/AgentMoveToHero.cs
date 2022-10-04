using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToHero : Follow
    {
        private float _minimalDistance = 1f;

        [SerializeField] private NavMeshAgent _agent;

        private Transform _heroTransform;

        public void Construct(Transform heroTransform) =>
            _heroTransform = heroTransform;

        private void Update()
        {
            if (Initialized() && IsHeroNotReached())
                _agent.destination = _heroTransform.position;
        }

        private bool Initialized() =>
            _heroTransform != null;

        private bool IsHeroNotReached() =>
            Vector3.Distance(_agent.transform.position, _heroTransform.position) >= _minimalDistance;
    }
}