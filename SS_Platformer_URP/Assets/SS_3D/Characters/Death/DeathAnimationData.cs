using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    public enum DeathType
    {
        NONE,
        LAUNCH_INTO_AIR,
        GROUND_SHOCK,
    }

    [CreateAssetMenu(fileName = "New ScriptableObject", menuName = "SS_Tutorial/Death/DeathAnimationData")]
    public class DeathAnimationData : ScriptableObject
    {
        public List<GeneralBodyPart> GeneralBodyParts = new List<GeneralBodyPart>();
        public RuntimeAnimatorController Animator;
        public DeathType deathType;
        public bool IsFacingAttacker;
    }

}