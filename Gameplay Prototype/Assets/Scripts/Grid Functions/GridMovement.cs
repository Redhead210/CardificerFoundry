/**
// File Name :         GridMovement.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Handles the individual jumps and the movements
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridMovement : MonoBehaviour
{
    public int tile_x;
    public int tile_y;
    public int moveSpeed = 30;
    public Vector3 moveTowards;
    public Vector2 start_pos;
    public Vector2 start_jump;
    public enum Dir { left, up, right, down };

    private void Start()
    {
        updateWorldPos();

        var new_x = start_pos.x + (tile_x * 2) + (tile_y * 2);
        var new_y = start_pos.y + tile_x - tile_y;

        moveTowards = new Vector3(new_x, new_y, -10 - tile_y);
        transform.position = new Vector3(new_x, new_y, -10 - tile_y);
        start_jump = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        updateWorldPos();
    }

    public void updateWorldPos()
    {
        start_pos = FindObjectOfType<IsoGridGenerator>().gameObject.transform.position;

        var d1 = Vector2.Distance(start_jump, moveTowards);
        var d2 = Vector2.Distance(transform.position, moveTowards);
        float jump; 

        if (gameObject.CompareTag("Saw"))
        {
            jump = 0;
        }
        else
        {
            jump = d2 - (Mathf.Max(0, d2 - (d1 / 2)));
        }

        var new_x = start_pos.x + (tile_x * 2) + (tile_y * 2);
        var new_y = start_pos.y + tile_x - tile_y;

        moveTowards = new Vector3(new_x, new_y+jump, -10-tile_y);
        if (Vector2.Distance(moveTowards,transform.position) != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTowards, moveSpeed * Time.deltaTime);
        }
        else
        {
            start_jump = transform.position;
        }
    }

    /// <summary>
    /// Checks if this entity can move to a certain tile x and y
    /// </summary>
    /// <param name="grid_x">x on the grid</param>
    /// <param name="grid_y">y on the grid</param>
    /// <returns></returns>
    public bool canMove(int grid_x, int grid_y)
    {
        if (grid_x < 0 || grid_x >= IsoGridGenerator.tilegrid.GetLength(0))
        {
            return false;
        }
        if (grid_y < 0 || grid_y >= IsoGridGenerator.tilegrid.GetLength(1))
        {
            return false;
        }

        return (IsoGridGenerator.tilegrid[grid_x, grid_y] != IsoGridGenerator.Tiles.None) && (GameManager.leverActivated || IsoGridGenerator.tilegrid[grid_x, grid_y] != IsoGridGenerator.Tiles.Door);
    }

    /// <summary>
    /// Returns an array of cords that change the x and y by a certain threshold
    /// </summary>
    /// <param name="delta_x">change in x</param>
    /// <param name="delta_y">change in y</param>
    /// <returns></returns>
    public int[] newCords(int delta_x, int delta_y)
    {
        return new int[] { tile_x + delta_x, tile_y + delta_y };
    }

    /// <summary>
    /// Returns an array of cords moving the current x and y in a certain direction.
    /// </summary>
    /// <param name="direction">direction of movement</param>
    /// <param name="magnitude">spaces moved</param>
    /// <returns></returns>
    public int[] newCords(Dir direction, int magnitude = 1)
    {
        switch (direction)
        {
            case Dir.left:
                return new int[] { tile_x - magnitude, tile_y };
            case Dir.up:
                return new int[] { tile_x, tile_y - magnitude };
            case Dir.right:
                return new int[] { tile_x + magnitude, tile_y };
            case Dir.down:
                return new int[] { tile_x, tile_y + magnitude };
        }
        return new int[] { tile_x, tile_y };
    }

    public bool compareCords(int[] cordsA, int[] cordsB)
    {
        return (cordsA[0] == cordsB[0]) && (cordsA[1] == cordsB[1]);
    }

    public void jumpTo(int[] cords)
    {
        tile_x = cords[0];
        tile_y = cords[1];
    }

    public void jumpTo(int x, int y)
    {
        tile_y = y;
        tile_x = x;
    }
}
