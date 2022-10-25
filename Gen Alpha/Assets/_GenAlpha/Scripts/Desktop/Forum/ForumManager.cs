using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eGamerTag
{
    RogueHeartAlpha,
    MoonbeamSeeker98,
    Electro_Knight_Hacks71,
    yourmom046,
    Xx_penguin_tacoz_xX,
    GlitchedDream00,
    Warrior_of_Ashes96,
    AcheronAlien,
    DragonBloodOrigin_70
}

public class ForumManager : MonoBehaviour
{
    
    private static ForumManager m_instance;

    public static ForumManager Instance { get { return m_instance; } }


    [SerializeField] private RectTransform m_postParent;
    [SerializeField] private GameObject m_forumScreen;
    [SerializeField] private GameObject m_forumPostTemplate;
    [SerializeField] private GameObject m_forumCommentTemplate;

    [SerializeField] private CharacterConfig[] m_characterConfigs;

    static Dictionary<eGamerTag, CharacterConfig> CharacterDict = new();

    private static Dictionary<string, ForumPostInfo> ChannelPosts = new();
    
    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }

        SetUpCharacters();
    }
    
    private void SetUpCharacters()
    {
        if (CharacterDict.Count > 0) return;
        foreach (var character in m_characterConfigs)
        {
            CharacterDict[character.GamerTag] = character;
        }
    }

    public CharacterConfig GetCharacterConfig(eGamerTag tag)
    {
        return CharacterDict[tag];
    }

    public void CreatePost(string postText)
    {
       
        ForumPostInfo info = ChannelPosts[postText];
        
        GameObject postObject = Instantiate(m_forumPostTemplate, m_forumPostTemplate.transform.position,
            m_forumPostTemplate.transform.rotation, m_postParent);

        CharacterConfig config = CharacterDict[info.characterTag];
        ForumPost forumPost = postObject.GetComponent<ForumPost>();
        
        forumPost.SetPost(config.GamerTagText, info.caption, config.ProfilePicture, info.timePosted, info.postTitle);
        forumPost.SetReactStats(info.reactions[0], info.reactions[1], info.reactions[2]);

        foreach (var comment in info.comments)
        {
            postObject = Instantiate(m_forumCommentTemplate, m_forumCommentTemplate.transform.position,
                m_forumCommentTemplate.transform.rotation, m_postParent);

            forumPost = postObject.GetComponent<ForumPost>();
            config = CharacterDict[comment.m_characterTag];
            string commentTitle = "Re: " + info.postTitle;
            forumPost.SetPost(config.GamerTagText, comment.comment, config.ProfilePicture, comment.time, commentTitle);
            
        }
    }

    public void CreatePostClass(string title, string caption, eGamerTag gTag, eChannel channel, string time, string date, int[] reaction, PostComment[] comments)
    {
        ForumPostInfo info = new ForumPostInfo(title, caption, gTag, channel, time, date, reaction, comments);
        ChannelPosts[title] = info;
        ChannelManager.Instance.CreateChannelPost(gTag, channel, title);
    }

    public void SetUpPostFeed(string caption)
    {
        foreach (Transform child in m_postParent) {
            Destroy(child.gameObject);
        }
        
        ChannelManager.Instance.CloseAllChannels();
        m_forumScreen.SetActive(true);
        CreatePost(caption);
    }
}
