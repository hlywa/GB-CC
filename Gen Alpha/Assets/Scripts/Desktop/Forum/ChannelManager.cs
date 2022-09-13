using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

public enum eChannel
{
    Introductions,
    Announcements,
    GeneralDiscussion,
    Rumors,
    ForumGames,
    ModdingHelp
}
public class ChannelManager : MonoBehaviour
{
    private static ChannelManager m_instance;
    public static ChannelManager Instance { get { return m_instance; } }
    
    [SerializeField] ForumChannel[] m_channels;
    static Dictionary<eChannel, ForumChannel> ChannelDict = new();
    
    private GameObject m_currentChannel;
    [SerializeField] private RectTransform m_homeTransform;
    [SerializeField] private GameObject m_channelPostTemplate;
    
    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }

        DefineDictionary();
    }

    void DefineDictionary()
    {
        if (ChannelDict.Count > 0) { return; }

        foreach (var channel in m_channels)
        {
            ChannelDict[channel.GetChannelType()] = channel;
            channel.GetChannelObject().SetActive(false);
        }
    }
    
    ForumChannel GetChannelForum(eChannel channel)
    {
        return ChannelDict[channel];
    }

    public void GoToChannel(eChannel channel)
    {
        m_currentChannel = ChannelDict[channel].GetChannelObject();
        m_currentChannel.SetActive(true);
        m_homeTransform.localScale = Vector3.zero;
    }

    public void CloseAllChannels()
    {
        foreach (var channel in m_channels)
        {
            channel.GetChannelObject().SetActive(false);
        }
    }

    public void EnableHomeScreen()
    {
        m_homeTransform.localScale = Vector3.one;
    }

    public void CreateChannelPost(eGamerTag character, eChannel channel, string postTitle)
    {
        GameObject postObject = Instantiate(m_channelPostTemplate, m_channelPostTemplate.transform.position,
            m_channelPostTemplate.transform.rotation, ChannelDict[channel].GetPostPosition());

        CharacterConfig config = ForumManager.Instance.GetCharacterConfig(character);
        ChannelPost channelPost = postObject.GetComponent<ChannelPost>();
        channelPost.SetChannelInfo(postTitle, config.m_gamerTagText);
      
    }

   
}
