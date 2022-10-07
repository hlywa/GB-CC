using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private GameObject m_screen;
    
    [SerializeField] private Color m_winColor;
    [SerializeField] private Color m_loseColor;
    [SerializeField] private Image m_backgroundColor;

    [SerializeField] private string m_winText;
    [SerializeField] private string m_loseText;
    [SerializeField] private TMP_Text m_headingText;

    [SerializeField] private GameObject m_restartButton;
    [SerializeField] private GameObject m_nextLevelButton;

    private void Start()
    {
        m_screen.SetActive(false);
    }

    public void ShowResultScreen(bool hasWon = true)
    {
        m_headingText.text = hasWon ? m_winText : m_loseText;
        m_backgroundColor.color = hasWon ? m_winColor : m_loseColor;
        m_nextLevelButton.SetActive(hasWon);
        m_screen.SetActive(true);
    }
    

}
