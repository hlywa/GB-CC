using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasMoved;

    public int tileSpeed;
    public float moveSpeed;

    private GridManager gm;

    [SerializeField] private InteractIcon m_icon;
 
	private Animator camAnim;
    private AudioSource source;

    [SerializeField] Tile m_leftTile;
    [SerializeField] Tile m_rightTile;
    [SerializeField] Tile m_upTile;
    [SerializeField] Tile m_downTile;

    private void Start()
    {
		source = GetComponent<AudioSource>();
		camAnim = Camera.main.GetComponent<Animator>();
        gm = FindObjectOfType<GridManager>();
        m_icon   = FindObjectOfType<InteractIcon>();
        GetWalkableTiles();

    }

    public void CheckForWinState()
    {
        Debug.Log("Puzzle completed");
        if (m_icon != null)
        {
            m_icon.Success();
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) ||Input.GetKeyDown(KeyCode.A)) && m_leftTile)
        {
            Move(m_leftTile.transform);
            if (m_leftTile.IsGoal() )
            {
                CheckForWinState();
            }
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && m_rightTile)
        {
            Move(m_rightTile.transform);
            if (m_rightTile.IsGoal())
            {
                CheckForWinState();
            }
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && m_upTile)
        {
            Move(m_upTile.transform);
            if (m_upTile.IsGoal())
            {
                CheckForWinState();
            }
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && m_downTile)
        {
            Move(m_downTile.transform);
            if (m_downTile.IsGoal() )
            {
                CheckForWinState();
            }
        }
    }

    void GetWalkableTiles() { // Looks for the tiles the unit can walk on
    
        m_leftTile = null;
        m_rightTile = null;
        m_upTile = null;
        m_downTile = null;
        
        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach (Tile tile in tiles) {
            if (Mathf.Abs(transform.position.x - tile.transform.position.x) + Mathf.Abs(transform.position.y - tile.transform.position.y) <= tileSpeed)
            { // how far he can move
                
                if (tile.isClear() == true)
                { // is the tile clear from any obstacles
                    //tile.Highlight();

                    if (transform.position.x > tile.transform.position.x)
                    {
                        m_leftTile = tile;
                    }
                    else if (transform.position.x < tile.transform.position.x)
                    {
                        m_rightTile = tile;
                    }
                    else if (transform.position.y > tile.transform.position.y)
                    {
                        m_downTile = tile;
                    }
                    else if (transform.position.y < tile.transform.position.y)
                    {
                        m_upTile = tile;
                    }
                }

            }          
        }
    }
    
    public void Move(Transform movePos)
    {
        gm.ResetTiles();
        StartCoroutine(StartMovement(movePos));
    }

    
    
    IEnumerator StartMovement(Transform movePos) { // Moves the character to his new position.


        while (transform.position.x != movePos.position.x) { // first aligns him with the new tile's x pos
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(movePos.position.x, transform.position.y), moveSpeed * Time.deltaTime);
            yield return null;
        }
        while (transform.position.y != movePos.position.y) // then y
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, movePos.position.y), moveSpeed * Time.deltaTime);
            yield return null;
        }

        hasMoved = true;
        GetWalkableTiles();
    }




}
/*
  
 
 */