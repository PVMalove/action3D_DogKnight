using CodeBase.Conditions.Logic;
using UnityEngine;

namespace CodeBase.Conditions.Door
{
    public class ChangeOpenReaction : Reaction
    {
        [SerializeField] private Animator _animator;

        public override void React()
        {
            _animator.Play("OpenDoorAnimation");
        }
    }
}