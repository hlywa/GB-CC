using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler
{
    [SerializeField] AudioClip m_hoverAudio;
    [SerializeField] AudioSource m_source;

    [SerializeField] private GameObject m_glow;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float Strength = 5f;

    private bool canPulse;
    private Coroutine m_coroutine;

    private void Start()
    {
        m_glow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_glow.SetActive(true);
        if (!m_source.isPlaying)
        {
            m_source.PlayOneShot(m_hoverAudio);
        }

        canPulse = true;
       m_coroutine= StartCoroutine(PulseEffect(Speed));
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
        m_glow.SetActive(false);
        canPulse = false;
        if (m_coroutine != null)
        {
            StopCoroutine(m_coroutine);
        }
    }

    IEnumerator PulseEffect(float time)
    {
        while (canPulse)
        {
        
            for(float t = 0; t < 1; t += Time.deltaTime / time)
            {
                var localScale = transform.localScale;
                localScale = new Vector3
                (
                    localScale.x + (Time.deltaTime * Strength * 2),
                    localScale.y + (Time.deltaTime * Strength * 2)
                );
                transform.localScale = localScale;
                yield return null;
            }
        
            for(float t = 0; t < 1; t += Time.deltaTime / time)
            {
                var localScale = transform.localScale;
                localScale = new Vector3
                (
                    localScale.x - (Time.deltaTime * Strength * 2),
                    localScale.y - (Time.deltaTime * Strength * 2)
                );
                transform.localScale = localScale;
                yield return null;
            }
        }
        
    }
}

