using UnityEngine;

namespace CodeBase.Logic.Animation
{
    public class BoolOperatorReturn : StateMachineBehaviour
    {
        [SerializeField] private string _boolName;
        [SerializeField] private bool _status;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
            animator.SetBool(_boolName, _status);
    }
}