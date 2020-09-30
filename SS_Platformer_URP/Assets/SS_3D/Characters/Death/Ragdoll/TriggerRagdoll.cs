using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/Death/TriggerRagdoll")]
    public class TriggerRagdoll : StateData
    {
        public float TriggerTiming;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (stateInfo.normalizedTime >= TriggerTiming)
            {
                if(!control.animationProgress.RagdollTriggered)
                {
                    if(control.SkinnedMeshAnimator.enabled)
                    {
                        control.animationProgress.RagdollTriggered = true;
                    }
                }
            }

          
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //CharacterControl control = characterState.GetCharacterControl(animator);
            //control.animationProgress.RagdollTriggered = false;
        }
    }
}
