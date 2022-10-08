// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;


namespace Fungus
{
    /// <summary>
    /// Writes text in a dialog box.
    /// </summary>
    [CommandInfo("Forum", 
        "SendMessage", 
        "Sends private message to player")]
    [AddComponentMenu("")]
    
    public class SendMessage : Command
    {

        [TextArea(5,10)]
        [SerializeField] protected string messageText = "";
        
        [Tooltip("Character that is posting")]
        [SerializeField] protected eGamerTag m_characterTag;
        
        [SerializeField] protected string timePosted = "";



        #region Public members

        public override void OnEnter()
        {
            PrivateMessageManager.Instance.SendPrivateMessage(m_characterTag, messageText);
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