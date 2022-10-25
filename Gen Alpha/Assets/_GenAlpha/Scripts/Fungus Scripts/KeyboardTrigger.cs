using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;

public class KeyboardTrigger : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;

    [SerializeField] FirstPersonController fpsController;

    [SerializeField] private string m_blockName;
    
    void OnTriggerEnter(Collider other)
    {
        if (m_blockName != "")
        {
            fpsController.enabled = false;
            flowchart.ExecuteBlock(m_blockName);
        }
        
    }
}
