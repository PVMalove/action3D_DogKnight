using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] public Attack _attack;
        [SerializeField] public TriggerObserver _triggerObserver;

        private void Start()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;

            _attack.DisableAttack();
        }

        private void TriggerEnter(Collider obj)
        {
            _attack.EnableAttack();
        }

        private void TriggerExit(Collider obj)
        {   
            _attack.DisableAttack();
        }
    }
}