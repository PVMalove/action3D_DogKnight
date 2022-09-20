using CodeBase.Conditions.Logic;
using UnityEngine;

namespace CodeBase.Conditions.TrapSpears
{
    public class ChangeSwingReaction : Reaction
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private float _timeLoweringSpears;
        [SerializeField] private float _distance;
        public override void React()
        {
            LeanTween.moveY(_gameObject, _distance, _timeLoweringSpears).setLoopPingPong().setEaseOutBack();
        }
    }
}