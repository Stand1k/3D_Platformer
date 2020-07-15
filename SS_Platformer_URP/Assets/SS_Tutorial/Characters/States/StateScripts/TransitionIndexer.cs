using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{

    public enum TransitionConditionType
    {
        UP, 
        DOWN,
        LEFT,
        RIGHT,
        ATTACK,
        JUMP,
        GRABBING_LEDGE,
    }

    [CreateAssetMenu(fileName = "New State", menuName = "SS_Tutorial/AbilityData/TransitionIndexer")]
    public class TransitionIndexer : StateData
    {
        public int Index;
        public List<TransitionConditionType> transitionConditions = new List<TransitionConditionType>();
    
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
          
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private bool MakeTransition(CharacterControl control)
        {
            foreach (TransitionConditionType c in transitionConditions)
            {
                switch (c)
                {
                    case TransitionConditionType.UP:
                        {
                           // control.MoveForward
                        }
                        break;

                    case TransitionConditionType.DOWN:
                        {

                        }
                        break;

                    case TransitionConditionType.LEFT:
                        {

                        }
                        break;

                    case TransitionConditionType.RIGHT:
                        {

                        }
                        break;

                    case TransitionConditionType.ATTACK:
                        {

                        }
                        break;

                    case TransitionConditionType.JUMP:
                        {

                        }
                        break;

                    case TransitionConditionType.GRABBING_LEDGE:
                        {

                        }
                        break;
                }
            }

            return true;
        }

    }

}