// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class PostComment
{
    public string name;
    public Sprite icon;
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
        // Removed this tooltip as users's reported it obscures the text box
        [TextArea(5,10)]
        [SerializeField] protected string caption = "";
        
        [Tooltip("Character that is posting")]
        [SerializeField] protected string posterName;

        [Tooltip("Portrait that represents speaking character")]
        [SerializeField] protected Sprite portrait;

        [SerializeField] protected string timePosted = "";

        [SerializeField] protected string datePosted = "";
        
        [SerializeField] protected  int[] reactions = new int[3]{0,0,0};

        [SerializeField] protected PostComment[] comments = new PostComment[] { };


        #region Public members
        

        /// <summary>
        /// Portrait that represents speaking character.
        /// </summary>
        public virtual Sprite Portrait { get { return portrait; } set { portrait = value; } }

    

        public override void OnEnter()
        {
            ForumManager.Instance.CreatePost(posterName, caption, portrait,  datePosted +" at " + timePosted, reactions);
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