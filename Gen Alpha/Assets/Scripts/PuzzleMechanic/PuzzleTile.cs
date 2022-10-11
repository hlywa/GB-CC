
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PuzzleTile : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_meshRenderer;
    [SerializeField] private Material m_normalMaterial;
    [SerializeField] private Material m_highlightedMaterial;
    
    [SerializeField] private LayerMask m_tileLayerMask;
    [SerializeField] private eTileType m_tileType;
    
    [SerializeField] private bool m_isWalkable;
    bool m_isHighlighted;
    
    [SerializeField]  bool m_isOccupied;
    [SerializeField]  PuzzlePawn m_occupiedBy;
    
    [SerializeField] PuzzleTile[] m_nearbyTiles = new PuzzleTile[7];
    private int m_nearbyTilesCount;
    private bool m_bIsZoomedIn;
    
    [SerializeField] float m_hoverAmount = 0.08f;
    [SerializeField] private AudioClip m_hoverSound;

    [SerializeField] private AudioClip[] m_playerFootsteps;
    [SerializeField] private AudioClip[] m_enemyFootsteps;
    
    private void Start()
    {
        var position = transform.position;
        var hitColliders = new Collider[7];
        m_nearbyTilesCount = Physics.OverlapSphereNonAlloc(position, 1f, hitColliders, m_tileLayerMask);

        for (int i = 0; i < m_nearbyTilesCount; i++)
        {
            var tile = hitColliders[i].GetComponent<PuzzleTile>();
            if (tile.IsWalkable())
            {
                m_nearbyTiles[i] = tile;
            }
        }
    }
    
   

    private void OnMouseEnter()
    {
        if (!m_isHighlighted || m_bIsZoomedIn) return;
        transform.localScale += new Vector3(m_hoverAmount, m_hoverAmount, m_hoverAmount);
        m_bIsZoomedIn = true;
        if (m_hoverSound)
        {
            PuzzleAudioManager.Instance.PlaySfx(m_hoverSound);
        }
    }

    private void OnMouseExit()
    {
        if (!m_bIsZoomedIn) return;
        transform.localScale -= new Vector3(m_hoverAmount, m_hoverAmount, m_hoverAmount);
        m_bIsZoomedIn = false;
    }
    
    private void OnMouseDown()
    {
        if (PuzzleManager.Instance.IsGamePaused) return;
        if (!m_isHighlighted || m_isOccupied) return;
        PuzzleManager.Instance.MovePlayerPawn(this);
    }

    bool IsWalkable()
    {
        return m_isWalkable;
    }

    public bool IsHighlighted()
    {
        return m_isHighlighted;
    }
    
    public void IsOccupied(PuzzlePawn pawn, bool state)
    {
        m_occupiedBy = pawn;
        m_isOccupied = state;
    }
    
    public bool HasPlayer()
    {
        return m_isOccupied && m_occupiedBy.IsPlayer();
    }
    
    Vector3 GetPosition()
    {
        return transform.position;
    }

    public AudioClip GetLandingSound(bool isPlayer)
    {
        return isPlayer ? m_playerFootsteps[Random.Range(0, m_playerFootsteps.Length)] : m_enemyFootsteps[Random.Range(0, m_enemyFootsteps.Length)];
    }
    
    #region Tile Highlights
    
    void UpdateTileVisuals()
    {
        if (!m_isWalkable) return;
        if (m_isOccupied)
        {
            m_occupiedBy.UpdateVisuals();
        }
        m_isHighlighted = true;
        m_meshRenderer.material = m_highlightedMaterial;
     }
     
     void ResetTileVisuals()
     {
         if (m_isOccupied)
         {
             m_occupiedBy.ResetVisuals();
         }
         m_isHighlighted = false;
         m_meshRenderer.material = m_normalMaterial;
     }
     
     public void HighlightNearbyTiles()
     {
         for (var i = 0; i < m_nearbyTilesCount; i++)
         {
             var tile = m_nearbyTiles[i];
             if (tile == null || tile.Equals(this)) continue;
             tile.UpdateTileVisuals();
         }
     }
    
     public void ResetNearbyTiles()
     {
         for (int i = 0; i < m_nearbyTilesCount; i++)
         {
             PuzzleTile tile = m_nearbyTiles[i];
             if (tile == null || tile.Equals(this)) continue;
             tile.ResetTileVisuals();
         }
     }
     
     #endregion

     
     public PuzzleTile GetClosestTile()
     {
         var playerPos = PuzzleManager.Instance.GetPlayerPosition();
         var nearest = m_nearbyTiles.Where(tile => tile != null && !tile.Equals(this) && (tile.m_occupiedBy == null || tile.m_occupiedBy.IsPlayer()))
             .OrderBy(t => Vector3.Distance(playerPos, t.GetPosition())).FirstOrDefault();
         return nearest;
     }

}
