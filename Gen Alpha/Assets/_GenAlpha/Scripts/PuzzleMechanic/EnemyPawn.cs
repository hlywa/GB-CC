
using System.Collections;
using UnityEngine;

public class EnemyPawn : PuzzlePawn
{
    [SerializeField] private AudioClip m_squishSound;
    [SerializeField] private float m_squishTime = 0.5f;
    
    protected override void OnMouseDown()
    {
        if (m_puzzleManager.IsGamePaused) return;
        if (!m_puzzleManager.IsPlayerTurn || !m_currentTile.IsHighlighted()) return;
        m_puzzleManager.MovePlayerPawn(m_currentTile);
        m_puzzleManager.KillEnemy(this);
        StartCoroutine(SquishEnemy(m_squishTime));
    }
    
    IEnumerator SquishEnemy(float duration)
    {
        yield return new WaitForSeconds(0.4f);
        float time = 0;
        Vector3 endScale = transform.localScale;
        PuzzleAudioManager.Instance.PlaySfx(m_squishSound);
        while (time <= duration)
        {
            time = time + Time.deltaTime;
            endScale.y = Mathf.Lerp(1, 0, time / duration);
            transform.localScale = endScale;
            yield return null;
        }
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
