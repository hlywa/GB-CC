using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Desktop/Forum/Character", order = 1)]
public class CharacterConfig : ScriptableObject
{
    public eGamerTag m_gamerTag;
    public string m_gamerTagText;
    public Sprite m_profilePicture;
    public string m_realName;
    public string m_description;
}