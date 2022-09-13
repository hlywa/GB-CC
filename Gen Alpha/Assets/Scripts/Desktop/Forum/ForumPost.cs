using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum eforumActions
{
    Like,
    Comment,
    Share,
    Save
}
public class ForumPost : MonoBehaviour
{
    [Header("Post Header References")]
    [SerializeField] private Image m_posterImage;
    [SerializeField] private TMP_Text m_postTitle;
    [SerializeField] private TMP_Text m_posterName;
    [SerializeField] private TMP_Text m_postDetails;
    
    [Header("Post Content References")]
    [SerializeField] private TMP_Text m_postCaption;
    [SerializeField] private Image m_postImage;
    
    [Header("Post Reaction References")]
    [SerializeField] private TMP_Text m_reactStats;
    [SerializeField] private Image m_LikeButton;
    [SerializeField] private Image m_SaveButton;

    [Header("Post Reaction Sprites")]
    [SerializeField] private Sprite m_defaultLikeIcon;
    [SerializeField] private Sprite m_selectedLikeIcon;
    [SerializeField] private Sprite m_defaultSaveIcon;
    [SerializeField] private Sprite m_selectedSaveIcon;

    [SerializeField] private GameObject m_reactBar;

    private bool m_hasLiked;
    private bool m_hasSaved;

    private int m_likes;
    private int m_comments;
    private int m_saves;


    public void SetPost(string name, string caption, Sprite icon, string time, string postTitle)
    {
        m_postTitle.text = postTitle;
        m_posterName.text = name;
        m_postCaption.text = caption;
        m_posterImage.sprite = icon;
        m_postDetails.text = time;
    }
    
    public void SetReactStats(int likes, int comments, int saves)
    {
        m_likes = likes;
        m_comments = comments;
        m_saves = saves;

        //..........got too carried away with tiny details like adding an 's' if there was more than one reaction
        m_reactStats.text = m_likes + " like"+ (m_likes > 0 ? "s     " : "     " ) + 
                            m_comments + " comment" + (m_comments > 0 ? "s     " : "     " ) + 
                            m_saves + " save"+ (m_saves > 0 ? "s     " : "     " );
    }

    public void UpdateButton(string buttonName)
    {
        switch (buttonName)
        {
            case "Like":
                m_hasLiked = !m_hasLiked;
                m_likes += m_hasLiked ? 1 : -1;
                m_LikeButton.sprite = m_hasLiked ? m_selectedLikeIcon : m_defaultLikeIcon;
                break;
            case "Save":
                m_hasSaved = !m_hasSaved;
                m_saves += m_hasSaved ? 1 : -1;
                m_SaveButton.sprite = m_hasSaved ? m_selectedSaveIcon : m_defaultSaveIcon;
                return;
            default:
                Debug.Log("Button not defined");
                return;
        }
        
        m_reactStats.text = m_likes + " like"+ (m_likes > 0 ? "s     " : "     " ) + 
                            m_comments + " comment" + (m_comments > 0 ? "s     " : "     " ) + 
                            m_saves + " save"+ (m_saves > 0 ? "s     " : "     " );
    }

    public void HideReactBar()
    {
        m_reactBar.SetActive(false);
    }
}
