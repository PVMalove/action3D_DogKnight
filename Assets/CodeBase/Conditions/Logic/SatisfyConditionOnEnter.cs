using UnityEngine;

namespace CodeBase.Conditions.Logic
{
    public class SatisfyConditionOnEnter : TriggerByTag
    {
        [SerializeField] private Condition _condition;
        [SerializeField] private Light _light;

        protected override void OnTriggerEnterWithTag(Collider other)
        {
            _light.color = Color.black;
            _condition.Satisfy();
        }
    }
}