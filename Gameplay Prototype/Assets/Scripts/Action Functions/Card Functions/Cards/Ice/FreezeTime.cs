/**
// File Name :         FreezeTime.cs
// Author :            Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Randomly distributes frost amongst enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : Card
{
    public override string cardClass()
    {
        return "FreezeTime";
    }

    public override string cardName()
    {
        return "Permafrost";
    }

    public override string cardDesc()
    {
        if(rank == 3)
        {
            return "Randomly apply a total of 15 frost across the enemies";
        }
        else if(rank == 2)
        {
            return "Randomly apply a total of 10 frost across the enemies";
        }
        else
        {
            return "Randomly apply a total of 7 frost across the enemies";
        }
        
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 5;
        }
        if (rank == 2)
        {
            return 6;
        }
        return 7;
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override string FlavorText()
    {
        return "Chance and ice. My two favorite things!";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var l = CharacterBehaviour.getAllEnemies();
        if(rank == 3)
        {
            for(int i = 0; i < 15; i++)
            {
                var bruh = Random.Range(0, l.Length);
                l[bruh].ApplyEffect("frost", 1);
            }
        }
        else if(rank == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                var bruh = Random.Range(0, l.Length);
                l[bruh].ApplyEffect("frost", 1);
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                var bruh = Random.Range(0, l.Length);
                l[bruh].ApplyEffect("frost", 1);
            }
        }
    }
}
