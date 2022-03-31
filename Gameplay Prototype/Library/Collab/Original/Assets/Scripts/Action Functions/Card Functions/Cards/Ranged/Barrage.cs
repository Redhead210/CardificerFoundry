/**
// File Name :         Barrage.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that deals damage to all enemies with Mark
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : Card
{
    public override string cardClass()
    {
        return "Barrage";
    }

    public override string cardName()
    {
        return "Barrage";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply Mark to an enemy. Deal 6 damage to all enemies with Mark. Apply Mark to all enemies.";
        }
        if (rank == 2)
        {
            return "Apply Mark to an enemy. Deal 4 damage to all enemies with Mark.";
        }

        return "Apply Mark to an enemy. Deal 3 damage to all enemies with Mark.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 6;
        }
        return 7;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override string FlavorText()
    {
        return "When you have two full six shooters everything starts to look like a target.";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 3;
        if (rank == 2)
        {
            d = 4;
        }
        if (rank == 3)
        {
            d = 6;
        }

        cb.ApplyEffect("mark", 1);

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (c.HasEffect("mark"))
            {
                c.TakeDamage(d);
            }

            if (rank == 3)
            {
                c.ApplyEffect("mark", 1);
            }
        }
    }
}
