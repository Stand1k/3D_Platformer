﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    public class SelectCameraState : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayableCharacterType[] arr = System.Enum.GetValues(typeof(PlayableCharacterType)) as PlayableCharacterType[];
          
            foreach (PlayableCharacterType p in arr)
            { 
                animator.SetBool(p.ToString(), false);
            }
        }

    }

}