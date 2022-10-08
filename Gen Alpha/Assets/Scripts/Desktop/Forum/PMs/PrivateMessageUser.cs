using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrivateMessageUser : MonoBehaviour
{
    [SerializeField] private eGamerTag m_gamerTag;
    [SerializeField] private Image m_profilePicture;
    [SerializeField] private TMP_Text m_name;
    [SerializeField] private TMP_Text m_lastText;

    public void UpdateUser( eGamerTag gTag, Sprite picture)
    {
        m_gamerTag = gTag;
        m_profilePicture.sprite = picture;
        CharacterConfig config = ForumManager.Instance.GetCharacterConfig(gTag);
        m_name.text = "<b>"+ config.RealName + "</b> <color=\"grey\"><size=80%> @"+ config.GamerTagText;
    }

    public void UpdateLastMessage(string text)
    {
        m_lastText.text = text;
    }
}
