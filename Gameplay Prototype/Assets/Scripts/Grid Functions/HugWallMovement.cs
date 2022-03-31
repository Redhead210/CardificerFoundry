/**
// File Name :         HugWallMovement.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Prototype movement behaviour
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugWallMovement : EnemyGridMovement
{
    public Dir[] moveOrder;

    void Start()
    {
        do
        {
            tile_x = Random.Range(2, (int)Mathf.Sqrt(IsoGridGenerator.tilegrid.Length));
            tile_y = Random.Range(2, (int)Mathf.Sqrt(IsoGridGenerator.tilegrid.Length));
        }
        while (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.None);

        var new_x = start_pos.x + (tile_x * 2) + (tile_y * 2);
        var new_y = start_pos.y + tile_x - tile_y;

        moveTowards = new Vector3(new_x, new_y, -10 - tile_y);
        transform.position = new Vector3(new_x, new_y, -10 - tile_y);


        if (tile_y < (int)Mathf.Sqrt(IsoGridGenerator.tilegrid.Length)/2)
        {
            moveOrder = new Dir[] { Dir.left, Dir.up, Dir.right, Dir.down };
        }
        else
        {
            moveOrder = new Dir[] { Dir.down, Dir.right, Dir.up, Dir.left };
        }
    }

    public override void moveAction()
    {
        this.updateMoveOptions();

        var moveDir = -1;
        foreach (Dir d in moveOrder)
        {
            if (!compareCords(newCords(d),lastPos) && moveOptions[(int)d])
            {
                moveDir = (int)d;
            }
        }

        if (moveDir == -1)
        {
            var ph = lastPos;
            lastPos = new int[] { tile_x, tile_y };

            jumpTo(ph);
        }
        else
        {
            lastPos = new int[] { tile_x, tile_y };
            jumpTo(newCords((Dir)moveDir));
        }
    }
}
