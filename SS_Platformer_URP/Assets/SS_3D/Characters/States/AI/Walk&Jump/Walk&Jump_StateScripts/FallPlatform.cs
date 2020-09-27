﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AI/FallPlatform")]
    public class FallPlatform : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(control.transform.position.z < control.aiProgress.pathFindingAgent.EndSphere.transform.position.z)
            {
                control.FaceForward(true);
            }
            else if(control.transform.position.z > control.aiProgress.pathFindingAgent.EndSphere.transform.position.z)
            {
                control.FaceForward(false);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(control.IsFacingForward())
            {
                if(control.transform.position.z < control.aiProgress.pathFindingAgent.EndSphere.transform.position.z)
                {
                    control.MoveRight = true;
                    control.MoveLeft = false;
                }
                else
                {
                    control.MoveRight = false;
                    control.MoveLeft = true;

                    animator.gameObject.SetActive(false);
                    animator.gameObject.SetActive(true);
                }
            }
            else
            {
                if (control.transform.position.z > control.aiProgress.pathFindingAgent.EndSphere.transform.position.z)
                {
                    control.MoveRight = false;
                    control.MoveLeft = true;
                }
                else
                {
                    control.MoveRight = false;
                    control.MoveLeft = false;

                    animator.gameObject.SetActive(false);
                    animator.gameObject.SetActive(true);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
