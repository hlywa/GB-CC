using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzle : MonoBehaviour
{
    
    [SerializeField] private int m_currentPuzzle = -1;
    [SerializeField] private GameObject m_resultScreen;
    [SerializeField] private GameObject[] m_puzzles;


    public void SetUpNextPuzzle()
    {
        if (m_currentPuzzle != -1)
        {
            Destroy(m_puzzles[m_currentPuzzle]);
        }
        
        if (m_currentPuzzle + 1 >= m_puzzles.Length) { return; }

        m_resultScreen.SetActive(false);
        m_currentPuzzle++;
        m_puzzles[m_currentPuzzle].SetActive(true);
        //PuzzleManager.Instance.UnPauseGame();
        PuzzleAudioManager.Instance.StopAudioSource();

    }

    public void SetUpSamePuzzle()
    {
        if (m_currentPuzzle != -1)
        {
            m_puzzles[m_currentPuzzle].SetActive(false);
        }
        PuzzleAudioManager.Instance.StopAudioSource();
        m_resultScreen.SetActive(false);
        m_puzzles[m_currentPuzzle].SetActive(true);
        PuzzleManager.Instance.UnPauseGame();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpNextPuzzle();
    }

    
}
