using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    [CreateAssetMenu(fileName = "Settings", menuName = "SS_Tutorial/Settings/FrameSettings")]
    public class FrameSettings : ScriptableObject
    {
        [Range(0.01f, 1f)]
        public float TimeScale;
        public int TargetFPS;
    }
}
