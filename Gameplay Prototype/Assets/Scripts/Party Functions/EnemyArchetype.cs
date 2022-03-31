/**
// File Name :         EnemyArchetype.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : The basis of the indivigual enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy")]
public class EnemyArchetype : ScriptableObject
{
    public int maxhp;
    public Sprite sprite;
    public string cname;
    public string[] deck;
    public Card.CardTypes[] types;
    public string[] effects;


    public static Character[] toCharacter(EnemyArchetype[] c)
    {
        var r = new Character[c.Length];
        for (var i = 0; i < c.Length; i++)
        {
            r[i] = c[i];
        }
        return r;
    }

    public static implicit operator Character(EnemyArchetype c)
    {
        return new Character(c.maxhp, c.cname, c.types, c.deck, 0, c.sprite);
    }

}
