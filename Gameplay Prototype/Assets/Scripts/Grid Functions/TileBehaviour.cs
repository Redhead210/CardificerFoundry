/**
// File Name :         TileBehaviour.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the spawning of each indivigual tile
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public int tile_x = 0;
    public int tile_y = 0;

    public static List<GameObject> GetAllTileObjects(IsoGridGenerator.Tiles tile)
    {
        var l = Mathf.Sqrt(IsoGridGenerator.tilegrid.Length);
        var r = new List<GameObject>();
        for (int _x = 0; _x < l; _x++) {
            for (int _y = 0; _y < l; _y++)
            {
                if (IsoGridGenerator.tilegrid[_x,_y] == tile)
                {
                    r.Add(IsoGridGenerator.objectgrid[_x, _y]);
                }
            }
        }
        return r;
    }
}
