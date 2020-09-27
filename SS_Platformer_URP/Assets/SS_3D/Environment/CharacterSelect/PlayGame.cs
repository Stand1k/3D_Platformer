using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ss_3d
{
    public class PlayGame : MonoBehaviour
    {
        public CharacterSelect characterSelect;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(characterSelect.SelectedCharacterType != PlayableCharacterType.NONE)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(SS_Scenes.Main.ToString());
                }
                else
                {
                    Debug.Log("Must select character first");
                }
               
            }
        }
    }

}