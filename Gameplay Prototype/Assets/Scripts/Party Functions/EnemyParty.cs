/**
// File Name :         EnemyParty.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : The basis of the enemy parties
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyParty")]
public class EnemyParty : ScriptableObject
{
    public EnemyArchetype[] party;
    public Sprite sprite;
    public string pname;
    public GameObject prefab;
    public int XP;
    public int Gold;

    public void Create(int x, int y)
    {
        var o = Instantiate(prefab,GameManager.gm.isoGridManager.transform);
        
        var c = o.GetComponent<EnemyGridMovement>();
        c.tile_x = x;
        c.tile_y = y;
        

        c.party = party;
        c.gold = Gold;
        c.xp = XP;
        o.GetComponent<SpriteRenderer>().sprite = sprite;
        
    }
}
