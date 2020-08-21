using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    public class AttackInfo : MonoBehaviour
    {
        public CharacterControl Attacker = null;
        public Attack AttackAbility;
        public List<string> ColliderName = new List<string>();
        public DeathType deathType;
        public bool MustCollide;
        public bool MustFaceAttacker;
        public float LethalRange;
        public int MaxHits;
        public int CurrentHits;
        public bool isRegister;
        public bool isFinished;

        public void ResetInfo(Attack attack, CharacterControl attacker)
        {
            isRegister = false;
            isFinished = false;
            AttackAbility = attack;
            Attacker = attacker;
        }

        public void Register(Attack attack)
        {
            isRegister = true;

            AttackAbility = attack;
            ColliderName = attack.ColliderNames;
            deathType = attack.deathType;
            MustCollide = attack.MustCollide;
            MustFaceAttacker = attack.MustFaceAttacker;
            LethalRange = attack.LethalRange;
            MaxHits = attack.MaxHits;
            CurrentHits = 0;
        }

        private void OnDisable()
        {
            isFinished = true;
        }

    }

}