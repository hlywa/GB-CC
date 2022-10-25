using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChannelPost : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private TMP_Text m_postTitleText;
    [SerializeField] private TMP_Text m_posterText;
    [SerializeField] private TMP_Text m_viewNumberText;
    [SerializeField] private TMP_Text m_replyNumberText;
    
    [SerializeField] private int m_viewsMinRange = 20;
    [SerializeField] private int m_viewsMaxRange = 400;

    private int m_topicNumber;
    private int m_postNumber;
    private int m_postID;


    private void Start()
    {
        m_viewNumberText.text = Random.Range(m_viewsMinRange, m_viewsMaxRange).ToString();
    }

    public void SetChannelInfo(string topicTitle, string posterName)
    {
        m_postTitleText.text = topicTitle;
        m_posterText.text = "By "+ posterName;
        
        m_button.onClick.AddListener(delegate { ForumManager.Instance.SetUpPostFeed(topicTitle); });
       
    }
    
    
 
}

    

