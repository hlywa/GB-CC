using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "Character", menuName = "Desktop/Forum/Character", order = 1)]
public class CharacterConfig : ScriptableObject
{
    [FormerlySerializedAs("m_gamerTag")] public eGamerTag GamerTag;
    [FormerlySerializedAs("m_gamerTagText")] public string GamerTagText;
    [FormerlySerializedAs("m_profilePicture")] public Sprite ProfilePicture;
    [FormerlySerializedAs("m_realName")] public string RealName;
    [FormerlySerializedAs("m_description")] public string Description;
}