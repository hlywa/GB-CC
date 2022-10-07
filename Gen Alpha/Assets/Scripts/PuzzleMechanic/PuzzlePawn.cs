
using System;
using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class PuzzlePawn : MonoBehaviour
{
    [SerializeField] protected ePawnType m_pawnType;
    [SerializeField] private LayerMask m_tileLayerMask;

    [SerializeField] private MeshRenderer[] m_meshRenderers;
    [SerializeField] private Material m_normalMaterial;
    [SerializeField] private Material m_highlightedMaterial;
    
    [SerializeField] MMFeedbacks m_landingFeedback;
    protected PuzzleManager m_puzzleManager;
    protected PuzzleTile m_currentTile;

    protected bool m_isMoving;
    private void Start()
    {
        m_puzzleManager = PuzzleManager.Instance;
        var tileCollider = new Collider[1];
        Physics.OverlapSphereNonAlloc(transform.position, 0.05f, tileCollider, m_tileLayerMask);
        if (!tileCollider[0]) return;
        
        m_currentTile = tileCollider[0].GetComponent<PuzzleTile>();
        m_currentTile.IsOccupied(this, true);
    }
    
    protected virtual void OnMouseDown()
    {
    }

    public virtual bool IsEnemy()
    {
        return false;
    }
    
    public virtual bool IsPlayer()
    {
        return false;
    }
    public void MovePawn(PuzzleTile newTile)
    {
        if (m_isMoving) return;
        
        m_currentTile.IsOccupied(null, false);
        m_currentTile = newTile;
        StartCoroutine(Move(newTile.gameObject.transform.position, 0.5f));
        m_currentTile.IsOccupied(this, true);
    }
    
    IEnumerator Move(Vector3 endPos, float time)
    {
        m_isMoving = true;
        Vector3 beginPos = transform.position;
        endPos.y += 1;
        for(float t = 0; t < 1; t += Time.deltaTime / time)
        {
            transform.position = Parabola(beginPos, endPos, 2f, t);
            yield return null;
        }
        m_isMoving = false;
        m_landingFeedback?.PlayFeedbacks();
        m_puzzleManager.UpdateTurn();
    }
    
    public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;
        var mid = Vector3.Lerp(start, end, t);
        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    public void UpdateVisuals()
    {
        foreach (var meshRenderer in m_meshRenderers)
        {
            meshRenderer.material = m_highlightedMaterial;
        }
    }

    public void ResetVisuals()
    {
        foreach (var meshRenderer in m_meshRenderers)
        {
            meshRenderer.material = m_normalMaterial;
        }
    }
}
