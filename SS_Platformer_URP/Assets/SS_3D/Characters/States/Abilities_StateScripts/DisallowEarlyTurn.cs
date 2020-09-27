using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/DisallowEarlyTurn")]
    public class DisallowEarlyTurn : StateData
    {
        public bool MustRequireMovement;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            control.animationProgress.disallowEarlyTurn = true;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
