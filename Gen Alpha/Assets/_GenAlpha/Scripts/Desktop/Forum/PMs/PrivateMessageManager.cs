using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateMessageManager : MonoBehaviour
{
    
    private static PrivateMessageManager m_instance;

    [SerializeField] private GameObject m_privateMessageSentPrefab;
    [SerializeField] private GameObject m_privateMessageRecievedPrefab;
    [SerializeField] private GameObject m_privateMessageUserPrefab;
    
    [SerializeField] private Transform m_privateUserTransform;
    [SerializeField] private Transform m_privateMessageTransform;
    public static PrivateMessageManager Instance { get { return m_instance; } }


    private Dictionary<eGamerTag, List<PrivateMessage>> m_messagesTracker = new ();
    
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

    public void SendPrivateMessage(eGamerTag etag, string message)
    {
        CharacterConfig config = ForumManager.Instance.GetCharacterConfig(etag);

        //Instantiate Message
        GameObject prefab = null;
        
        if (etag == eGamerTag.RogueHeartAlpha)
        {
            prefab = m_privateMessageSentPrefab;
        }
        else
        {
            prefab = m_privateMessageRecievedPrefab;
        }

        GameObject pMessage = Instantiate(prefab, Vector3.zero, Quaternion.identity,
            m_privateMessageTransform);

        PrivateMessage privateMessage = pMessage.GetComponent<PrivateMessage>();
        privateMessage.UpdatePrivateMessage(config.ProfilePicture, message);
        
        
        //Check if user is already valid
        if (!m_messagesTracker.ContainsKey(etag) && etag != eGamerTag.RogueHeartAlpha)
        {
            GameObject user = Instantiate(m_privateMessageUserPrefab, Vector3.zero, Quaternion.identity,
                m_privateUserTransform);
            PrivateMessageUser pUser = user.GetComponent<PrivateMessageUser>();
            pUser.UpdateUser(etag, config.ProfilePicture);
            pUser.UpdateLastMessage(message);
            m_messagesTracker[etag] = new List<PrivateMessage>();
        }
        
       //Stores info
       m_messagesTracker[etag].Add(privateMessage);
    }
}
