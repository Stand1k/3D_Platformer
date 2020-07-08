﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/Idle")] 
    public class Idle : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            CharacterControl control = characterState.GetCharacterControl(animator);

            if(control.Attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }

            if(control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveLeft && control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.MoveLeft && !control.MoveRight) 
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }
    }
}
