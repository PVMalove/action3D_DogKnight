using System.Collections.Generic;
using CodeBase.Conditions.Logic;
using UnityEngine;

namespace CodeBase.Conditions.Door
{
    public class ReactOnEnter : TriggerByTag
    {
        [SerializeField] private List<Condition> _satisfiedConditions;
        [SerializeField] private List<Condition> _unsatisfiedConditions;
        [SerializeField] private List<Reaction> _reactions;
        [SerializeField] private Light _light;

        protected override void OnTriggerEnterWithTag(Collider other)
        {
            _light.color = new Color32(14,118,15,229);
            
            foreach (var condition in _satisfiedConditions)
            {
                if (!condition.IsSatisfied)
                    return;
            }

            foreach (var condition in _unsatisfiedConditions)
            {
                if (condition.IsSatisfied)
                    return;
            }

            foreach (var reaction in _reactions)
            {
                reaction.React();
            }
        }
    }
}