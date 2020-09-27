using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    public class AttackManager : Singleton<AttackManager>
    {
        public List<AttackInfo> CurrentAttacks = new List<AttackInfo>();
    }
}
