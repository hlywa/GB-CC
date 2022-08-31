using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractIcon : MonoBehaviour
{
    [SerializeField] private Camera m_fpsCamera;
    [SerializeField] private Camera m_camera;

    
    [SerializeField] private FirstPersonController m_controller;
    [SerializeField] private GameObject m_bridge;

    [SerializeField] private GameObject puzzle;



    public void Interact()
    {
        m_camera.enabled = true;
        m_fpsCamera.enabled = false;
        
        puzzle.SetActive(true);
    }

    public void Success()
    {
        m_fpsCamera.enabled = true;
        m_camera.enabled = false;

        m_controller.enabled = true;
        m_controller.gameObject.SetActive(true);
        m_bridge.SetActive(true);
        puzzle.SetActive(false);
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
