using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum eDesktopLayout
{
    Hardwired,
    Conspiracy
}
public class DesktopManager : MonoBehaviour
{
    [SerializeField] private eDesktopLayout m_currentDesktopLayout;

    [SerializeField] private Animator m_gameAnimator;
    [SerializeField] private LevelManager m_levelManager;
    
    [SerializeField] private RectTransform m_gameButton;
    [SerializeField] private RectTransform m_musicButton;
    [SerializeField] private RectTransform m_forumButton;
    [SerializeField] private RectTransform m_settingButton;
    
    [SerializeField] private Image m_desktopWallpaper;
    [SerializeField] private TMP_Text[] m_buttonTexts;
    [SerializeField] private LayoutConfig[] m_desktopLayouts;

    private bool m_openedMusic;
    private bool m_openedForum;
    private bool m_openedSettings;
    
    Dictionary<eDesktopLayout, LayoutConfig> LayoutDict = new();
    private static DesktopManager m_instance;
    public static DesktopManager Instance { get { return m_instance; } }


    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }

        SetUpIntialLayout();
    }
    
    private void SetUpIntialLayout()
    {
        foreach (var layout in m_desktopLayouts)
        {
            LayoutDict[layout.m_layOut] = layout;
        }

        SetUpLayout(m_currentDesktopLayout);
    }

    public void SetUpLayout(eDesktopLayout newLayout)
    {
        m_currentDesktopLayout = newLayout;

        var config = LayoutDict[newLayout];
        
        m_gameButton.localPosition = config.m_gameAppPosition;
        m_musicButton.localPosition = config.m_musicAppPosition;
        m_forumButton.localPosition = config.m_forumAppPosition;
        m_settingButton.localPosition = config.settingsAppPosition;
        
        foreach (var text in m_buttonTexts)
        {
            text.font = config.m_appFont;
        }

        UpdateWallpaper(config.m_wallpaper);
    }
    
    public void UpdateWallpaper(Sprite newWallpaper)
    {
        m_desktopWallpaper.sprite = newWallpaper;
    }

    public void SelectLayout(string layoutName)
    {
        var layout = m_currentDesktopLayout;
        switch (layoutName)
        {
            case "Hardwired":
                layout = eDesktopLayout.Hardwired;
                break;
            case "Conspiracy":
                layout = eDesktopLayout.Conspiracy;
                break;
        }
        SetUpLayout(layout);
    }

    public void OpenedForum()
    {
        m_openedForum = true;
    }
    public void OpenedSettings()
    {
        m_openedSettings = true;
    }
    public void OpenedMusic()
    {
        m_openedMusic = true;
    }

    public void OpenGame()
    {
        if (m_openedForum && m_openedMusic && m_openedSettings)
        {
            m_levelManager.LoadLevel("Puzzle1");
        }
        else
        {
            m_gameAnimator.SetTrigger("OpenPlayer");
        }
    }
}
