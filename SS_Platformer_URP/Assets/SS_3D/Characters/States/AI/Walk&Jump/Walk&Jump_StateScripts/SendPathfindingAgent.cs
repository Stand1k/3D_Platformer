using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ss_3d
{
    public enum AI_Walk_Transitions
    {
        start_walking,
        jump_platform,
        fall_platform,
        start_running,
    }

    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AI/SendPathfindingAgent")]
    public class SendPathfindingAgent : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(control.aiProgress.pathFindingAgent == null)
            {
                GameObject p = Instantiate(Resources.Load("PathfindingAgent", typeof(GameObject)) as GameObject);
                control.aiProgress.pathFindingAgent = p.GetComponent<PathFindingAgent>();
            }

            control.aiProgress.pathFindingAgent.GetComponent<NavMeshAgent>().enabled = false;
            control.aiProgress.pathFindingAgent.transform.position = control.transform.position;
            control.aiProgress.pathFindingAgent.GoToTarget();
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if(control.aiProgress.pathFindingAgent.StartWalk)
            {
                animator.SetBool(AI_Walk_Transitions.start_walking.ToString(), true);
                animator.SetBool(AI_Walk_Transitions.start_running.ToString(), true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(AI_Walk_Transitions.start_walking.ToString(), false);
            animator.SetBool(AI_Walk_Transitions.start_running.ToString(), false);
        }
    }

}
