/**
// File Name :         EnemyGridMovement.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Dictates how the character moves
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGridMovement : GridMovement
{
    public int[] lastPos = { 0, 0 };
    public bool[] moveOptions = { false, false, false, false };
    public EnemyArchetype[] party;
    public int gold;
    public int xp;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = new int[] {tile_x,tile_y};

        var new_x = start_pos.x + (tile_x * 2) + (tile_y * 2);
        var new_y = start_pos.y + tile_x - tile_y;
    }

    public abstract void moveAction();

    public void updateMoveOptions()
    {
        //moveOptions [0] Left, [1] Up, [2] Right, [3] Down
        moveOptions[0] = canMove(tile_x - 1, tile_y);
        moveOptions[1] = canMove(tile_x, tile_y - 1);
        moveOptions[2] = canMove(tile_x + 1, tile_y);
        moveOptions[3] = canMove(tile_x, tile_y + 1);
    }
}
