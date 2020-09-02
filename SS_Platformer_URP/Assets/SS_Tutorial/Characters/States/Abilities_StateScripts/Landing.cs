using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/Landing")]
    public class Landing : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
            animator.SetBool(TransitionParameter.Move.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}