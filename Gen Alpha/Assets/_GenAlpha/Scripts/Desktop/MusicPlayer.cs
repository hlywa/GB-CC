using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Song
{
    public Sprite AlbumCover;
    public string SongName;
    public AudioClip Audio;
}

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer m_instance;

    public static MusicPlayer Instance { get { return m_instance; } }
    
    [SerializeField] private TMP_Text m_songNameText;
    [SerializeField] private Image m_coverImage;
    [SerializeField] private AudioSource m_source;
    [SerializeField] private Song[] m_songs;

    [SerializeField] private Slider m_progressBar;
    [SerializeField] private Image m_playButtonImage;
    [SerializeField] private Image m_loopButtonImage;

    [SerializeField] private Sprite m_playSprite;
    [SerializeField] private Sprite m_pauseSprite;

    [SerializeField] private Sprite m_loopEnabledSprite;
    [SerializeField] private Sprite m_loopDisabledSprite;
    
    private bool m_isPlaying;
    private bool m_isLooping;

    private int m_currentSongIndex;
    
    
    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            m_instance = this;
        }

        InitialSetUp();
    }
    
    private void InitialSetUp()
    {
        m_isPlaying = true;
        m_isLooping = false;
        m_source.loop = true;
        m_playButtonImage.sprite = m_pauseSprite;
        m_currentSongIndex = 0;
        UpdateSong(m_songs[0]);
    }

    public void ToggleLoop()
    {
        m_loopButtonImage.sprite = m_isLooping ? m_loopDisabledSprite : m_loopEnabledSprite;
        m_isLooping = !m_isLooping;
        
    }
    public void ToggleAudio()
    {
        if (m_isPlaying)
        {
            m_source.Pause();
            m_playButtonImage.sprite = m_playSprite;
            
        }
        else
        {
            m_source.UnPause();
            m_playButtonImage.sprite = m_pauseSprite;
        }
        
        m_isPlaying = !m_isPlaying;
        
    }

    private void UpdateSong(Song song)
    {
        m_songNameText.text = song.SongName;
        m_coverImage.sprite = song.AlbumCover;
        m_source.clip = song.Audio;
        m_source.Play();
    }

    public void PlayNextSong()
    {
        m_currentSongIndex = (m_currentSongIndex + 1 < m_songs.Length) ? m_currentSongIndex + 1 : 0;
        UpdateSong(m_songs[m_currentSongIndex]);
    }

    void RepeatSong()
    {
        UpdateSong(m_songs[m_currentSongIndex]);
    }
    
    public void PlayPreviousSong()
    {
        m_currentSongIndex = (m_currentSongIndex - 1 >= 0) ? m_currentSongIndex - 1 : m_songs.Length - 1;
        UpdateSong(m_songs[m_currentSongIndex]);
    }
    
    public void ChangeAudioTime()
    {
        m_source.time = m_source.clip.length * m_progressBar.value;
    }
    
    public void Update()
    {
        m_progressBar.value = m_source.time / m_source.clip.length;

        if (!m_source.isPlaying && m_isPlaying)
        {
            if (m_isLooping)
            {
                RepeatSong();
            }
            else
            {
                PlayNextSong();
            }
        }
    }
}
