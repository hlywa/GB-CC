using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : PuzzleTile
{
    protected override void TileSelect()
    {
        if (PuzzleManager.Instance.IsGamePaused) return;
        if (!m_isHighlighted || m_isOccupied) return;
        Debug.Log("ON WATER TILE");
        PuzzleManager.Instance.MovePlayerPawn(this);
    }
}
