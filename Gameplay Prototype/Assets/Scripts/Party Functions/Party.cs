/**
// File Name :         Party.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Holds the characters in your party
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public Sprite axeman;
    public Sprite stabman;
    public Sprite gunman;
    public Sprite iceman;
    public static Character[] party;
    public static EnemyArchetype[] enemyParty;

    void Start()
    {
        if (party == null)
        {
            /*
            party = new Character[3];
            party[0] = Character.CharacterGen(2);
            party[1] = Character.CharacterGen(2);
            party[2] = Character.CharacterGen(2);
            */
            ResetParty();
        }
        else
        {
            foreach (Character c in party)
            {
                c.hp = c.maxhp;
            }
        }
        
    }

    public static void ResetParty()
    {
        /*
        party = new Character[3];
        party[0] = Character.CharacterGen(2);
        party[1] = Character.CharacterGen(2);
        party[2] = Character.CharacterGen(2);
        */

        party = new Character[2];
        party[0] = new Character((Character)Resources.Load("Starting Members/Guardian"));
        if(GameManager.act == -1)
        {
            party[1] = new Character((Character)Resources.Load("Starting Members/Tutorial"));
        }
        else
        {
            party[1] = Character.CharacterGen(1);
        }
        
    }

    public static int GetLowestLevel()
    {
        if (party == null)
        {
            return 1;
        }

        var r = 69;
        foreach (Character c in party)
        {
            if (c.level < r)
            {
                r = c.level;
            }
        }

        return r;
    }

    public static int GetHighestLevel()
    {
        if (party == null)
        {
            return 1;
        }

        var r = 0;
        foreach (Character c in party)
        {
            if (c.level > r)
            {
                r = c.level;
            }
        }

        return r;
    }
}
