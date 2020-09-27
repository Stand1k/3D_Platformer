using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    public class Settings : MonoBehaviour
    {
        public FrameSettings frameSettings;

        private void Awake()
        {
            Debug.Log("timeScale: " + frameSettings.TimeScale);
            Time.timeScale = frameSettings.TimeScale;

            Debug.Log("target FrameRate: " + frameSettings.TargetFPS);
            Application.targetFrameRate = frameSettings.TargetFPS;
        }
    }
}
