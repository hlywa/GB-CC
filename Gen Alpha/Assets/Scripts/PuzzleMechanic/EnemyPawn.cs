
public class EnemyPawn : PuzzlePawn
{

    protected override void OnMouseDown()
    {
        if (m_puzzleManager.IsGamePaused) return;
        if (!m_puzzleManager.IsPlayerTurn || !m_currentTile.IsHighlighted()) return;
        m_puzzleManager.KillEnemy(this);
        m_puzzleManager.MovePlayerPawn(m_currentTile);
        Destroy(this.gameObject);
        //Add some ceremony or sfx here.
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
        
        if (tile.HasPlayer())
        {
            m_puzzleManager.LosePuzzle();
        }
        
        MovePawn(tile);
    }
}
