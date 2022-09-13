using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[CreateAssetMenu(fileName = "DesktopLayout", menuName = "Desktop/Layout", order = 1)]
public class LayoutConfig : ScriptableObject
{
    public eDesktopLayout m_layOut;

    public Sprite m_wallpaper;
    public TMP_FontAsset m_appFont;
    
    public Vector3 m_gameAppPosition;
    public Vector3 m_musicAppPosition;
    public Vector3 m_forumAppPosition;
    public Vector3 settingsAppPosition;

    
}