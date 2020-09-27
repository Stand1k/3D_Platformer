using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ss_3d
{
    public enum PlayableCharacterType
    {
        NONE,
        YELLOW,
        RED,
        GREEN,
    }

    [CreateAssetMenu(fileName = "characterSelect", menuName = "SS_Tutorial/CharacterSelect/CharacterSelect")]

    public class CharacterSelect : ScriptableObject
    {
        public PlayableCharacterType SelectedCharacterType;
    }

}