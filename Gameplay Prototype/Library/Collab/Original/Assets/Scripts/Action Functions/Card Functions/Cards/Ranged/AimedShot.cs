/**
// File Name :         AimedShot.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that applies Mark and deals damage to the highest hp enemy
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedShot : Card
{
    public override string cardClass()
    {
        return "AimedShot";
    }

    public override string cardName()
    {
        return "Aimed Shot";
    }

    public override string FlavorText()
    {
        return "Just because you aim, doesn't mean you'll hit it.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 4 Mark to an enemy. Deal 7 damage to the enemy with the highest health twice.";
        }
        if (rank == 2)
        {
            return "Apply 2 Mark to an enemy. Deal 6 damage to the enemy with the highest health.";
        }
        return "Apply Mark to an enemy. Deal 5 damage to the enemy with the highest health.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 5;
        }
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 5;
        var m = 1;
        var r = 1;
        if (rank == 2)
        {
            d = 6;
            m = 2;
        }
        if (rank == 3)
        {
            d = 7;
            m = 4;
            r = 2;
        }

        cb.ApplyEffect("mark",m);

        for (int i = 0; i < r; i++)
        {
            var t = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllEnemies());
            t.TakeDamage(d);
        }
    }
}
