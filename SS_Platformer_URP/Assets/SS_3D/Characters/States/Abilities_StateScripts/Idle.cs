﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/Idle")] 
    public class Idle : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            animator.SetBool(TransitionParameter.Move.ToString(), false);

            CharacterControl control = characterState.GetCharacterControl(animator);
            control.animationProgress.disallowEarlyTurn = false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            CharacterControl control = characterState.GetCharacterControl(animator);

            if(control.animationProgress.AttackTriggered)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }

            if(control.Jump)
            {
                if(!control.animationProgress.Jumped)
                {
                    animator.SetBool(TransitionParameter.Jump.ToString(), true);
                }
            }
            else
            {
                control.animationProgress.Jumped = false;
            }

            if (control.MoveLeft && control.MoveRight)
            {
               //empty
            }
            else if (control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
            else if (control.MoveLeft)
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
