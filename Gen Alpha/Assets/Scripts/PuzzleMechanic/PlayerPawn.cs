using UnityEngine;

public class PlayerPawn : PuzzlePawn
{
    [SerializeField] private AudioClip m_selectSound;

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
}
