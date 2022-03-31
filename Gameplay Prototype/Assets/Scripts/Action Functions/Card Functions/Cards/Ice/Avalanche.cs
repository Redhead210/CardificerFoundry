/**
// File Name :         Avalanche.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that applies Frost and deals damage to slow enemies
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : Card
{
    public override string cardClass()
    {
        return "Avalanche";
    }

    public override string cardName()
    {
        return "Avalanche";
    }

    public override string cardDesc()
    {
        if (rank == 1)
        {
            return "Apply 4 Frost to all enemies who have acted. If they haven't, they take 10 damage instead.";
        }
        if (rank == 3)
        {
            return "Apply 6 Frost to all enemies who have acted. If they haven't, they take 16 damage instead.";
        }
        return "Apply 5 Frost to all enemies who have acted. If they haven't, they take 12 damage instead.";
    }

    public override Color cardColor()
    {
        return new Color(0, 0.3f, 0.6f);
    }

    public override int cardSpeed()
    {
        if (rank == 1)
        {
            return 8;
        }
        if (rank == 3)
        {
            return 6;
        }
        return 7;
    }
    public override string FlavorText()
    {
        return "Don't yell too loud!";
    }


    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {

        var f = 4;
        var d = 10;

        if (rank == 2)
        {
            d = 12;
            f = 5;
        }
        else if (rank == 3)
        {
            d = 16;
            f = 6;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (c.HasActed())
            {
                c.ApplyEffect("frost", f);
                c.Particle(BattleManager.Effects.Frost);
            }
            else
            {
                c.TakeDamage(d,"CRUSH!");
                c.Particle(BattleManager.Effects.Punch);
            }
        }
    }
}
