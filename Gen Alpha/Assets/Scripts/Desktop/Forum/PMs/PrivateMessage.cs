using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrivateMessage : MonoBehaviour
{
    [SerializeField] private Image m_profilePicture;
    [SerializeField] private TMP_Text m_message;

    public void UpdatePrivateMessage(Sprite image, string text)
    {
        m_profilePicture.sprite = image;
        m_message.text = text;
    }

}
