using System.Collections;
using UnityEngine;

public class PlayerPawn : PuzzlePawn
{
    [SerializeField] private AudioClip m_selectSound;
    [SerializeField] private float m_drownTime = 2.0f;
   
    protected override  void OnMouseDown()
    {
        if (m_puzzleManager.IsGamePaused || !m_puzzleManager.IsPlayerTurn) return;
        m_currentTile.HighlightNearbyTiles();
        m_puzzleManager.UpdateSelection(m_currentTile);
        if (m_selectSound)
        {
            PuzzleAudioManager.Instance.PlaySfx(m_selectSound);
        }
    }
    
    public override bool IsEnemy()
    {
        return false;
    }
    
    public override bool IsPlayer()
    {
        return true;
    }

    public void WaterTravel()
    {
        StartCoroutine(Drown());
    }

    IEnumerator Drown()
    { 
        m_currentTile.IsOccupied(null, false);
        m_isMoving = true;
        float timeElapsed = 0;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        endPos.y = 0.49f;

        while (timeElapsed < m_drownTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, timeElapsed / m_drownTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
        StartCoroutine(ReemergefromWater());
    }
    
    IEnumerator ReemergefromWater()
    {
        WaterTile newTile = m_puzzleManager.GetRandomWaterTile(m_currentTile);

        Vector3 newPos = newTile.transform.position;
        newPos.y = 0.49f;
        transform.position = newPos;
        
        m_currentTile.IsOccupied(null, false);
        
        float timeElapsed = 0;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        endPos.y = 2.1f;

        while (timeElapsed < m_drownTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, timeElapsed / m_drownTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
        m_isMoving = false;
        m_puzzleManager.UpdateTurn();

        m_currentTile = newTile;
        m_currentTile.IsOccupied(this, true);

    }
    
    
}
