/**
// File Name :         WanderMovement.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Primary movement option for enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderMovement : EnemyGridMovement
{
    void Start()
    {
        var new_x = start_pos.x + (tile_x * 2) + (tile_y * 2);
        var new_y = start_pos.y + tile_x - tile_y;

        moveTowards = new Vector3(new_x, new_y, -10 - tile_y);
        transform.position = new Vector3(new_x, new_y, -10 - tile_y);
    }

    public override void moveAction()
    {
        moveAction(0);
    }

    private void moveAction(int t = 0)
    {
        t++;
        if (t < 420)
        {
            var hasMoved = false;

            while (!hasMoved)
            {
                var m = newCords((Dir)Random.Range(0, 4));
                if (canMove(m[0], m[1]))
                {
                    hasMoved = true;
                    jumpTo(m);
                }
            }

            foreach (EnemyGridMovement e in FindObjectsOfType<EnemyGridMovement>())
            {
                if (e != this && e.tile_x == tile_x && e.tile_y == tile_y)
                {
                    moveAction(t);
                    break;
                }
            }

        }
    }
}
