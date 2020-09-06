using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ss_tutorial
{
    public enum AI_Walk_Transitions
    {
        start_walking,
        jump_platform,
        fall_platform,
    }

    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AI/StartWalking")]
    public class StartWalking : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            Vector3 dir = control.aiProgress.pathFindingAgent.StartSphere.transform.position - control.transform.position;

            if (dir.z > 0f)
            {
                control.MoveRight = true;
                control.MoveLeft = false;
            }
            else
            {
                control.MoveRight = false;
                control.MoveLeft = true;
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            Vector3 dist = control.aiProgress.pathFindingAgent.StartSphere.transform.position - control.transform.position;

            //NPC STOPING AND JUMPING
            if (control.aiProgress.pathFindingAgent.StartSphere.transform.position.y < control.aiProgress.pathFindingAgent.EndSphere.transform.position.y)
            {
                if (Vector3.SqrMagnitude(dist) < 0.01f)
                {
                    control.MoveRight = false;
                    control.MoveLeft = false;

                        animator.SetBool(AI_Walk_Transitions.jump_platform.ToString(), true);
                }
            }

            //NPC FALLING
            if (control.aiProgress.pathFindingAgent.StartSphere.transform.position.y > control.aiProgress.pathFindingAgent.EndSphere.transform.position.y)
            {
                animator.SetBool(AI_Walk_Transitions.fall_platform.ToString(), true);
            }

            //Straightening
            if (control.aiProgress.pathFindingAgent.StartSphere.transform.position.y == control.aiProgress.pathFindingAgent.EndSphere.transform.position.y)
            {
                if (Vector3.SqrMagnitude(dist) < 0.5f)
                {
                    control.MoveRight = false;
                    control.MoveLeft = false;

                    //temp solution
                    Vector3 playerDist = control.transform.position - CharacterManager.Instance.GetPlayableCharacter().transform.position;

                    if(playerDist.sqrMagnitude > 1f)
                    {
                        animator.gameObject.SetActive(false);
                        animator.gameObject.SetActive(true);
                    }
                }
            } 

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(AI_Walk_Transitions.jump_platform.ToString(), false);
            animator.SetBool(AI_Walk_Transitions.fall_platform.ToString(), false);
        }
    }

}
