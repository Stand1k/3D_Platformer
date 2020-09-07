using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_tutorial
{
    public class LayerChanger : MonoBehaviour
    {
        public Layers LayerType;
        public bool ChangeAllChildren;

        public void ChangeLayer(Dictionary<string, int> layerDic)
        {
            if(!ChangeAllChildren)
            {
                gameObject.layer = layerDic[LayerType.ToString()];
            }
            else
            {
                Transform[] arr = this.gameObject.GetComponentsInChildren<Transform>();

                foreach(Transform t in arr)
                {
                    t.gameObject.layer = layerDic[LayerType.ToString()];
                }
            }
        }
    }

}