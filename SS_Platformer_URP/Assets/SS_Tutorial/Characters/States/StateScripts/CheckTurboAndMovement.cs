﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/CheckTurboAndMovement")]
    public class CheckTurboAndMovement : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if ((control.MoveLeft || control.MoveRight) && control.Turbo)
            {
                animator.SetBool(TransitionParameter.Turbo.ToString(), true);
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
            else
            {
                animator.SetBool(TransitionParameter.Turbo.ToString(), false);
                animator.SetBool(TransitionParameter.Move.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
