using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAudioManager : MonoBehaviour
{
    private static PuzzleAudioManager m_instance;
    public static PuzzleAudioManager Instance { get { return m_instance; } }

    [SerializeField] private AudioSource m_sfxAudioSource;
    [SerializeField] private AudioSource m_bgmAudioSource;
    [SerializeField] private AudioClip m_bgm;
    private Coroutine m_coroutine;

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }

        if (m_bgm != null)
        {
            PlayBGM(m_bgm);
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        if (clip == null) return;
        m_sfxAudioSource.PlayOneShot(clip);
    }

    public void PlayResultSound(AudioClip intro, AudioClip loop)
    {
        m_bgmAudioSource.Stop();
        m_coroutine = StartCoroutine(PlayLoopAfterIntro());
        IEnumerator PlayLoopAfterIntro()
        {
            m_bgmAudioSource.PlayOneShot(intro);
            yield return new WaitForSeconds(4);
            m_bgmAudioSource.loop = true;
            m_bgmAudioSource.clip = loop;
            m_bgmAudioSource.Play();
        }
    }

    public void PlayBGM(AudioClip bgm)
    {
        if (m_coroutine != null)
        {
            StopCoroutine(m_coroutine);
        }
        m_bgmAudioSource.Stop();
        m_bgmAudioSource.clip = bgm;
        m_bgmAudioSource.Play();

    }

    public void StopAudioSource()
    {
        m_bgmAudioSource.Stop();
        if (m_coroutine != null)
        {
            StopCoroutine(m_coroutine);
        }
    }
}
