using UnityEngine;

namespace CodeBase.Conditions.Logic
{
    public class SatisfyConditionOnEnter : TriggerByTag
    {
        [SerializeField] private Condition _condition;
       
        protected override void OnTriggerEnterWithTag(Collider other)
        {
            _condition.Satisfy();
        }
    }
}