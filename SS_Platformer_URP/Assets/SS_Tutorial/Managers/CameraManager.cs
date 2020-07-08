﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    public class CameraManager : Singleton<CameraManager>
    {
        private Coroutine routine;
        private CameraController cameraController;
        public CameraController CAM_CONTROLLER
        {
            get
            {
                if(cameraController == null)
                {
                    cameraController = GameObject.FindObjectOfType<CameraController>();
                }
                return cameraController;
            }
        }

        //private void Awake()
        //{
        //    Time.timeScale = 0.3f;
        //}

        IEnumerator _CamShake(float sec)
        {
            CAM_CONTROLLER.TriggerCamera(CameraTrigger.Shake);

            yield return new WaitForSeconds(sec);
            CAM_CONTROLLER.TriggerCamera(CameraTrigger.Default);
        }

        public void ShakeCamera(float sec)
        {
            if(routine != null)
            {
                StopCoroutine(routine);
            }

            routine = StartCoroutine(_CamShake(sec));
        }
    }

}