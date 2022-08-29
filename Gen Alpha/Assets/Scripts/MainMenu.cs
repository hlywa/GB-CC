using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator m_fadeAnimator;
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

