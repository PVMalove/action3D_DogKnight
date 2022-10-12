using UnityEngine;

namespace CodeBase.Logic.Animation
{
    public class BoolOperator : StateMachineBehaviour
    {
        [SerializeField] private string _boolName;
        [SerializeField] private bool _status;
        
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => 
            animator.SetBool(_boolName, !_status);

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
            animator.SetBool(_boolName, !_status);

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => 
            animator.SetBool(_boolName, _status);
    }
}