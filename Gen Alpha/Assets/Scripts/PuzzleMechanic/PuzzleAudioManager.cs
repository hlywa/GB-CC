using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAudioManager : MonoBehaviour
{
    private static PuzzleAudioManager m_instance;
    public static PuzzleAudioManager Instance { get { return m_instance; } }

    [SerializeField] private AudioSource m_audioSource;

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        m_audioSource.PlayOneShot(clip);
    }

    public void PlayResultSound(AudioClip intro, AudioClip loop)
    {
        print("Playing result sound");
        StartCoroutine(PlayLoopAfterIntro());
        
        IEnumerator PlayLoopAfterIntro()
        {
            m_audioSource.PlayOneShot(intro);
            yield return new WaitForSeconds(4);
            m_audioSource.loop = true;
            m_audioSource.clip = loop;
            m_audioSource.Play();
        }
    }
}
