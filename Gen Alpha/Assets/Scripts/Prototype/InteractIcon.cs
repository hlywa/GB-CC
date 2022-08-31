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
    [SerializeField] private CharacterController m_characterController;
    [SerializeField] private GameObject m_bridge;

    [SerializeField] private GameObject puzzle;



    public void Interact()

    {
       // m_controller.enabled = false;
        //m_characterController.enabled = false;
        
      //  m_camera.enabled = true;
      //  m_fpsCamera.enabled = false;
       
      // m_controller.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        puzzle.SetActive(true);
    }

    public void Success()
    {
      //  m_characterController.enabled = true;
       // m_fpsCamera.enabled = true;
     //   m_camera.enabled = false;
     //   m_controller.enabled = true;
        
        m_controller.gameObject.SetActive(true);
        m_bridge.SetActive(true);
        puzzle.SetActive(false);
    }
}
