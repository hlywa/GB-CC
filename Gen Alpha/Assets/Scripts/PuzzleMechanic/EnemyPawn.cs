
using System.Collections;
using UnityEngine;

public class EnemyPawn : PuzzlePawn
{
    [SerializeField] private AudioClip m_squishSound;

    protected override void OnMouseDown()
    {
        if (m_puzzleManager.IsGamePaused) return;
        if (!m_puzzleManager.IsPlayerTurn || !m_currentTile.IsHighlighted()) return;
        m_puzzleManager.KillEnemy(this);
        m_puzzleManager.MovePlayerPawn(m_currentTile);
        PuzzleAudioManager.Instance.PlaySfx(m_squishSound);
        Destroy(this.gameObject);
    }
    
    public override bool IsEnemy()
    {
        return true;
    }
    
    public override bool IsPlayer()
    {
        return false;
    }

    public void MoveToRandomTile()
    {
        PuzzleTile tile = m_currentTile.GetClosestTile();
        StartCoroutine(MoveWithDelay(0.3f));
        
        IEnumerator MoveWithDelay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            MovePawn(tile);
            if (tile.HasPlayer())
            {
                m_puzzleManager.LosePuzzle();
            }
            
        }
    }
}
