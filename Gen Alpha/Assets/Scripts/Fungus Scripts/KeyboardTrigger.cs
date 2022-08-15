using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTrigger : MonoBehaviour
{
    void OnEnterTrigger(Collider other)
    {
        Debug.Log("Entered");
    }
}
