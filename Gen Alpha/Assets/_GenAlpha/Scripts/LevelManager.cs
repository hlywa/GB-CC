using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    
    [SerializeField] AudioMixer MusicMixer;
    [SerializeField] AudioMixer SFXMixer;

    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SoundSlider;
    
    [SerializeField] private Animator m_fadeAnimator;
    [SerializeField] private GameObject m_SettingScreen;
    private bool isSettingsOpen;

    private void Start()
    {
        if (m_SettingScreen != null)
        {
            m_SettingScreen.SetActive(false);
            MusicMixer.GetFloat("MusicVolume", out var vol);
            MusicSlider.value = vol;
            SFXMixer.GetFloat("SFXVolume", out vol);
            SoundSlider.value = vol;
        }
    }


    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_SettingScreen != null)
        {
            isSettingsOpen = !isSettingsOpen;
            m_SettingScreen.SetActive(isSettingsOpen);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            index++;
            if (index >= SceneManager.sceneCountInBuildSettings)
            {
                index = 1;
            }
            SceneManager.LoadScene(index);
        }
    }

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("SFXVolume", volume);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string levelName)
    {
        m_fadeAnimator.SetTrigger("FadeOut");
        StartCoroutine(LoadLevelAsync());
        
        IEnumerator LoadLevelAsync()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        
    }
    
}

