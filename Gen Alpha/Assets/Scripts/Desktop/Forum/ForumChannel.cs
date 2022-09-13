using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ForumChannel : MonoBehaviour
{
    [SerializeField] private GameObject m_channelReference;
    [SerializeField] private Transform m_postPosition;
    
    [SerializeField] private TMP_Text m_channelNameText;
    [SerializeField] private TMP_Text m_channelDescText;
    [SerializeField] private TMP_Text m_topicNumberText;
    [SerializeField] private TMP_Text m_postNumberText;
    [SerializeField] private Image m_channelIconImage;

    [SerializeField] private string m_channelName;
    [SerializeField] private string m_channelDescription;
    [SerializeField] private Sprite m_channelIcon;
    [SerializeField] private eChannel m_channelType;

    private int m_topicNumber;
    private int m_postNumber;


    private void Start()
    {
        m_channelNameText.text = m_channelName;
        m_channelDescText.text = m_channelDescription;
        m_channelIconImage.sprite = m_channelIcon;
    }

    public GameObject GetChannelObject()
    {
        return m_channelReference;
    }
    
    public Transform GetPostPosition()
    {
        return m_postPosition;
    }

    public eChannel GetChannelType()
    {
        return m_channelType;
    }

    public void GoToChannel()
    {
        ChannelManager.Instance.GoToChannel(m_channelType);
    }
}
