﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ss_3d
{
    [CustomEditor(typeof(CharacterControl))]
    public class CharacterControlEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CharacterControl control = (CharacterControl)target;

            if(GUILayout.Button("Setup RagdollParts (BodyParts)"))
            {
                control.SetRagdollParts();
            }
        }
    }

}