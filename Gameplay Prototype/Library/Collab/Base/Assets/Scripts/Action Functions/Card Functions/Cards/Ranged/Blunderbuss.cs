/**
// File Name :         Blunderbuss.cs
// Author :            Jason Czech
// Creation Date :     1/26/2021
//
// Brief Description : Card that deals damage to all enemies and extra damage to one
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blunderbuss : Card
{
    public override string cardClass()
    {
        return "Blunderbuss";
    }

    public override string cardName()
    {
        return "Blunderbuss";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 3 damage to all enemies, then 7 damage and apply Mark to an enemy.";
        }
        if (rank == 2)
        {
            return "Deal 2 damage to all enemies, then 6 damage to an enemy.";
        }

        return "Deal 1 damage to all enemies, then 5 damage to an enemy.";
    }

    public override string FlavorText()
    {
        return " an anti-DAT weapon. Meaning, \"Destroys everything in dat general direction.\"";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        var ad = 1;
        if (rank == 2)
        {
            d = 6;
            ad = 2;
        }
        if (rank == 3)
        {
            d = 7;
            ad = 3;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.TakeDamage(ad);
        }

        cb.TakeDamage(d);

        if (rank == 3)
        {
            cb.ApplyEffect("mark", 1);
        }
    }
}
