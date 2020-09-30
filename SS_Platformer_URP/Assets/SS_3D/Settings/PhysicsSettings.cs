using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "Settings", menuName = "SS_Tutorial/Settings/PhysicsSettings")]
    public class PhysicsSettings : ScriptableObject
    {
        public int DefaultSolverVelocityIterations;
    }
}
