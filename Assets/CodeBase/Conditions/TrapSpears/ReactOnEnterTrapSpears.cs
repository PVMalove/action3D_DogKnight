using System.Collections.Generic;
using CodeBase.Conditions.Logic;
using UnityEngine;

namespace CodeBase.Conditions.TrapSpears
{
    public class ReactOnEnterTrapSpears : TriggerByTag
    {   
        [SerializeField] private List<Condition> _satisfiedConditions;
        [SerializeField] private List<Condition> _unsatisfiedConditions;
        [SerializeField] private List<Reaction> _reactions;
        protected override void OnTriggerEnterWithTag(Collider other)
        {
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