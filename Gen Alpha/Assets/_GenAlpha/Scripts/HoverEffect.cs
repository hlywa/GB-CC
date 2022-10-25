using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    [SerializeField] float amount;
    [SerializeField] private AudioClip m_hoverSound;

    private void OnMouseEnter()
    {
        transform.localScale += new Vector3(amount, amount, amount);
        if (m_hoverSound)
        {
            PuzzleAudioManager.Instance.PlaySfx(m_hoverSound);
        }
    }

    private void OnMouseExit()
    {
        transform.localScale -= new Vector3(amount, amount, amount);
    }
}
