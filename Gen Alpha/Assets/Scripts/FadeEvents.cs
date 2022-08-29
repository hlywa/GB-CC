using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEvents : MonoBehaviour
{
    [SerializeField] private GameObject m_Screen;
    [SerializeField] private GameObject m_playerController;

    public void ShowScreen()
    {
        m_Screen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //So the player does not keep colliding with the desktop collider 
        m_playerController.transform.position += new Vector3(0, 0, 0.25f);
    }
    
    public void HideScreen()
    {
        m_Screen.SetActive(false);
    }

}
