﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f,1f)]
        public float CheckTime;
        public float Distance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(stateInfo.normalizedTime >= CheckTime)
            {
                if (IsGrounded(control))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }           
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
 
        }

        bool IsGrounded(CharacterControl control)
        {
            
                if (control.contactPoints != null)
                {
                    foreach (ContactPoint c in control.contactPoints)
                    {
                        float colliderBottom = (control.transform.position.y + control.boxCollider.center.y) - (control.boxCollider.size.y / 2f);
                        float yDifference = Mathf.Abs(c.point.y - colliderBottom);

                        if (yDifference < 0.01f)
                        {
                           if(Mathf.Abs(control.RIGID_BODY.velocity.y) < 0.01f)
                           {
                               return true;
                           }
                        
                        }
                    }
                }
            

            if(control.RIGID_BODY.velocity.y < 0f)
            {
                foreach (GameObject o in control.BottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * 0.5f, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
                    {
                        if(!control.RagdollParts.Contains(hit.collider) && !Ledge.IsLedge(hit.collider.gameObject) && !Ledge.IsLedgeChecker(hit.collider.gameObject) && !Ledge.IsCharacter(hit.collider.gameObject))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }

}