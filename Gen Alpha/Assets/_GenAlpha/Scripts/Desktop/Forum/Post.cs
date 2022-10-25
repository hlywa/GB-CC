// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class PostComment
{
    public eGamerTag m_characterTag;
    public string comment;
    public string time;
    public int likes;
}

namespace Fungus
{
    /// <summary>
    /// Writes text in a dialog box.
    /// </summary>
    [CommandInfo("Forum", 
                 "Post", 
                 "Writes a new forum post")]
    [AddComponentMenu("")]
    
    public class Forum : Command
    {
        [SerializeField] protected string postTitle = "";
        
        [TextArea(5,10)]
        [SerializeField] protected string caption = "";
        
        [Tooltip("Character that is posting")]
        [SerializeField] protected eGamerTag m_characterTag;

        [SerializeField] protected eChannel m_channel;

        [SerializeField] protected string timePosted = "";

        protected string datePosted = "";
        
        [SerializeField] protected  int[] reactions = new int[3]{0,0,0};

        [SerializeField] protected PostComment[] comments = new PostComment[] { };


        #region Public members

        public override void OnEnter()
        {
            ForumManager.Instance.CreatePostClass(postTitle, caption, m_characterTag, m_channel, timePosted, datePosted,
                reactions, comments);
           
            Continue();
            return;
        }
        

        public override Color GetButtonColor()
        {
            return new Color32(184, 210, 235, 255);
        }
        
        #endregion
    }
}