﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public bool AllowEarlyTurn;
        public bool LockDirection;
        public bool Constant;
        public AnimationCurve speedGraph;
        public float speed;
        public float BlockDistance;

        [Header("Momentum")]
        public bool UseMomentum;
        public float StartingMomentum;
        public float MaxMomentum;
        public bool ClearMomentumOnExit;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (AllowEarlyTurn && !control.animationProgress.disallowEarlyTurn)
            {
                if(control.MoveLeft)
                {
                    control.FaceForward(false);
                }

                if(control.MoveRight)
                {
                    control.FaceForward(true);
                }
            }

            control.animationProgress.disallowEarlyTurn = false;
            //control.animationProgress.AirMomentum = 0f;

            if(StartingMomentum > 0.001f)
            {
                if(control.IsFacingForward())
                {
                    control.animationProgress.AirMomentum = StartingMomentum;
                }
                else
                {
                    control.animationProgress.AirMomentum = -StartingMomentum;
                }
            }
        }

        private void ControlledMove(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
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
                if (!CheckFront(control))
                {
                    control.MoveForward(speed, speedGraph.Evaluate(stateInfo.normalizedTime));
                }
            }

            if (control.MoveLeft)
            {
                if (!CheckFront(control))
                {
                    control.MoveForward(speed, speedGraph.Evaluate(stateInfo.normalizedTime));
                }
            }

            CheckTurn(control);
        }

        private void CheckTurn(CharacterControl control)
        {
            if(!LockDirection)
            {
                if (control.MoveRight)
                {
                     control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }

                if (control.MoveLeft)
                {
                     control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if(UseMomentum)
            {
                UpdateMomentum(control, stateInfo);
            }
            else
            {
                if (Constant)
                {
                    ConstantMove(control, animator, stateInfo);
                }
                else
                {
                    ControlledMove(control, animator, stateInfo);
                }
            }

            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if(ClearMomentumOnExit)
            {
                control.animationProgress.AirMomentum = 0f;
            }
        }

        private void UpdateMomentum(CharacterControl control, AnimatorStateInfo stateInfo)
        {
            if(control.animationProgress.FrameUpdated)
            {
                return; 
            }

            control.animationProgress.FrameUpdated = true;

            if (control.MoveRight)
            {
                control.animationProgress.AirMomentum += speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime;
            }

            if (control.MoveLeft)
            {
                control.animationProgress.AirMomentum -= speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime;
            }

            if(Mathf.Abs(control.animationProgress.AirMomentum) >= MaxMomentum)
            {
                if(control.animationProgress.AirMomentum > 0f)
                {
                    control.animationProgress.AirMomentum = MaxMomentum;
                }
                else if(control.animationProgress.AirMomentum < 0f)
                {
                    control.animationProgress.AirMomentum = -MaxMomentum;
                }
            }

            if(control.animationProgress.AirMomentum > 0f)
            {
                control.FaceForward(true);
            }
            else if(control.animationProgress.AirMomentum < 0f)
            {
                control.FaceForward(false);
            }

            if(!CheckFront(control))
            {
                control.MoveForward(speed, Mathf.Abs(control.animationProgress.AirMomentum));
            }
        }

        private void ConstantMove(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(!CheckFront(control))
            {
                control.MoveForward(speed, speedGraph.Evaluate(stateInfo.normalizedTime));
            }
        }

        bool CheckFront(CharacterControl control)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.1f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    if(!control.RagdollParts.Contains(hit.collider))
                    {
                        if(!IsBodyPart(hit.collider) && !Ledge.IsLedge(hit.collider.gameObject) && !Ledge.IsLedgeChecker(hit.collider.gameObject))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        bool IsBodyPart(Collider col)
        {
            CharacterControl control = col.transform.root.GetComponent<CharacterControl>();   

            if(control == null)
            {
                return false;
            }

            if(control.gameObject == col.gameObject)
            {
                return false;
            }

            if(control.RagdollParts.Contains(col))
            {
                return true;
            }

            return false;
        }

    }
}
