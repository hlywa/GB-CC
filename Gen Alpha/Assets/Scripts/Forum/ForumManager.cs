using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForumManager : MonoBehaviour
{
    
    private static ForumManager m_instance;

    public static ForumManager Instance { get { return m_instance; } }


    [SerializeField] private Transform m_postParent;
    [SerializeField] private GameObject m_forumPostTemplate;


    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }
    }

    public void CreatePost(string name, string caption, Sprite icon, string time, int[] reactions)
    {
        GameObject postObject = Instantiate(m_forumPostTemplate, m_forumPostTemplate.transform.position,
            m_forumPostTemplate.transform.rotation, m_postParent);

        ForumPost forumPost = postObject.GetComponent<ForumPost>();
        
        forumPost.SetPost(name, caption, icon, time);
        forumPost.SetReactStats(reactions[0], reactions[1], reactions[2]);
        
    }
}
