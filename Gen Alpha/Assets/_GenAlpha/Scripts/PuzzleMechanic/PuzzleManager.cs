
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityStandardAssets.Water;
using Random = UnityEngine.Random;


public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera m_camera1;
    [SerializeField] private CinemachineVirtualCamera m_camera2;
    private int m_currentCamera = 1;
    
    [SerializeField] private PlayerPawn m_playerPawn;
    private Transform m_playerTransform;

    [SerializeField] private AudioClip m_playerDeathSound;
    [SerializeField] private ResultScreen m_resultScreen;
    [SerializeField] private float m_screenDelay = 0.5f;
    
    private PuzzleTile m_currentTile;
    private List<EnemyPawn> m_enemies = new();

    [SerializeField] private Transform m_centrePoint;
    [SerializeField] private float m_rotationTime = 1f;
    [SerializeField] private GameObject m_lavaPrefab;
    
    private WaterTile[] m_waterTiles;
    private PuzzleTile[] m_lavaTiles;

    private bool m_isRotating;

    public bool IsGamePaused {get; private set;}
    public bool IsPlayerTurn {get; private set;}
    
    private void Awake() 
    { 
        // If there is an instance, and it's not this, delete self.
    
        if (Instance != null && Instance != this) 
        { 
           // Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        IsPlayerTurn = true;
    }

    private void Start()
    {
        m_playerTransform = m_playerPawn.transform;
        m_enemies =  FindObjectsOfType<EnemyPawn>().ToList();
        m_waterTiles =  FindObjectsOfType<WaterTile>();
        m_lavaTiles = FindObjectsOfType<PuzzleTile>().Where(tile => tile.GetTileType() == eTileType.Fire).ToArray();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeselectTile();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchCameras();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_isRotating) return;
            StartCoroutine(RotateGrid(90));
        }
        
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (m_isRotating) return;
            StartCoroutine(RotateGrid(-90));
        }
    }

    #region  Tile Selection
    
    public void UpdateSelection(PuzzleTile tile)
    {
        m_currentTile = tile;
    }

    void DeselectTile()
    {
        if (!m_currentTile) return;
        m_currentTile.ResetNearbyTiles();
        m_currentTile = null;
    }
    #endregion

    public Vector3 GetPlayerPosition()
    {
        return m_playerTransform.position;
    }

    public void MovePlayerPawn(PuzzleTile tile)
    {
        DeselectTile();
        m_playerPawn.MovePawn(tile);
    }

    public void TeleportPlayerPawn()
    {
        m_playerPawn.WaterTravel();
    }

    public void KillEnemy(EnemyPawn enemyPawn)
    {
        m_enemies.Remove(enemyPawn);
        if (m_enemies.Count <= 0)
        {
            WinPuzzle();
        }
    }

    private void WinPuzzle()
    {
        StartCoroutine(ShowResultScreen(true));
        Debug.Log("Puzzle Completed!");
    }

    public void LosePuzzle()
    {
        Destroy(m_playerPawn.gameObject);
        PuzzleAudioManager.Instance.PlaySfx(m_playerDeathSound);

        StartCoroutine(ShowResultScreen(false));
        Debug.Log("Puzzle Lost!");
    }

    void SwitchCameras()
    {
        switch (m_currentCamera)
        {
            case 1:
                m_camera1.Priority = 12;
                m_camera2.Priority = 13;
                m_currentCamera = 2;
                return;
            case 2:
                m_camera1.Priority = 13;
                m_camera2.Priority = 12;
                m_currentCamera = 1;
                return;
        }
    }

    public void MoveRandomEnemy()
    {
        if (m_enemies.Count.Equals(0)) return;
        var enemy = m_enemies[Random.Range(0, m_enemies.Count)];
        enemy.MoveToRandomTile();
    }

    public void UpdateTurn()
    {
        IsPlayerTurn = !IsPlayerTurn;
        if (!IsPlayerTurn)
        {
            MoveRandomEnemy();
            SpreadLava();
        }
    }

    void SpreadLava()
    {
        if (m_lavaTiles.Length == 0) return;
        PuzzleTile tile = m_lavaTiles[Random.Range(0, m_lavaTiles.Length)].GetRandomNonLavaNeighbor();
        tile.ChangeToLava(m_lavaPrefab);

    }
    
    IEnumerator ShowResultScreen(bool hasWon)
    {
        IsGamePaused = true;
        yield return new WaitForSeconds(m_screenDelay);
        m_resultScreen.ShowResultScreen(hasWon);
    }

    public void UnPauseGame()
    {
        IsGamePaused = false;
        IsPlayerTurn = true;
    }

    
    IEnumerator RotateGrid(int direction)
    {
        m_isRotating = true;
        float angle = 0;
        for(float t = 0; t < 1; t += Time.deltaTime / m_rotationTime)
        {
            var angleInterval = direction * Time.deltaTime / m_rotationTime;
            if (direction > 0)
            {
                if( angle + angleInterval > direction - 1f) { break; }
            }
            else
            {
                if( angle + angleInterval < direction + 1f) { break; }
            }
            angle += angleInterval;
            transform.RotateAround(m_centrePoint.position, Vector3.up, angleInterval);
            yield return null;
        }
        transform.RotateAround(m_centrePoint.position, Vector3.up, direction - angle );
        m_isRotating = false;
    }

    public WaterTile GetRandomWaterTile(PuzzleTile currentTile)
    {
        if (m_waterTiles.Length == 0) return null;
        var waterTile = m_waterTiles[Random.Range(0, m_waterTiles.Length)];
        if (m_waterTiles.Length == 1) return waterTile;
        while (waterTile.gameObject == currentTile.gameObject)
        {
            waterTile = m_waterTiles[Random.Range(0, m_waterTiles.Length)];
            Debug.Log("Selected same time, reselecting");
        }
        return waterTile;
    }


}
  

