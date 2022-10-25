using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutVariant : MonoBehaviour
{
   
    [SerializeField] private Sprite m_variantWallpaper;
    [SerializeField] private GameObject m_options;

    public Sprite GetWallpaper()
    {
        return m_variantWallpaper;
    }

    public void OnClick()
    {
        DesktopManager.Instance.UpdateWallpaper(m_variantWallpaper);
        m_options.SetActive(false);
        
    }
}
