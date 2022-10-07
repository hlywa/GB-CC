
public class PlayerPawn : PuzzlePawn
{
    protected override  void OnMouseDown()
    {
        if (m_puzzleManager.IsGamePaused || !m_puzzleManager.IsPlayerTurn) return;
        m_currentTile.HighlightNearbyTiles();
        m_puzzleManager.UpdateSelection(m_currentTile);
        
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
