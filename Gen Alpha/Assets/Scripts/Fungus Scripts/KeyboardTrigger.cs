using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;

public class KeyboardTrigger : MonoBehaviour
{
    public Flowchart flowchart;

    public FirstPersonController fpsController;
    
    void OnTriggerEnter(Collider other)
    {
        fpsController.enabled = false;

        flowchart.ExecuteBlock("Start");
    }
}
