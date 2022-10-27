using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public enum eDialogueEvent
{
    EnterBoard,
    DefeatEnemy,
    EnemyInCheck,
    PuzzleComplete,
    PuzzleLost,
    JumpInWater,
    FifthTurn,
    TenthTurn,
    FirstTimeLava,
    ForumDM
}
public class DialogueEventManager : MonoBehaviour
{
    public static DialogueEventManager Instance { get; private set; }
    
    [SerializeField] private Flowchart m_flowchart;
    private void Awake() 
    { 
        // If there is an instance, and it's not this, delete self.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    private void Start()
    {
        if (m_flowchart == null)
        {
            m_flowchart = GetComponent<Flowchart>();
        }
    }


    public void SayDialogue(eDialogueEvent eventType)
    {
        MessageReceived[] receivers = m_flowchart.GetComponents<MessageReceived>();
        if (receivers != null)
        {
            foreach (var receiver in receivers)
            {
                receiver.OnSendFungusMessage(eventType.ToString());
            }
        }
    }

}
