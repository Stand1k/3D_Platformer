﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/ResetLocalPosition")]
    public class ResetLocalPosition : StateData
    {
        public bool OnStart;
        public bool OnEnd;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           if(OnStart)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                control.SkinnedMeshAnimator.transform.localPosition = Vector3.zero;
                control.SkinnedMeshAnimator.transform.localRotation = Quaternion.identity;
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
         
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnEnd)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                control.SkinnedMeshAnimator.transform.localPosition = Vector3.zero;
                control.SkinnedMeshAnimator.transform.localRotation = Quaternion.identity;
            }
        }

      
    }

}