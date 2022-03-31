/**
// File Name :         VolletShot.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage based on mark and the highest health enemy
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyShot : Card
{
    public override string cardClass()
    {
        return "VolleyShot";
    }

    public override string cardName()
    {
        return "Trick Shot";
    }

    public override string FlavorText()
    {
        return "No one said being a gunslinger required so much geometry.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 7 damage and apply 2 Mark to the enemy with the highest health. If it had Mark, repeat this.";
        }
        if (rank == 2)
        {
            return "Deal 6 damage and apply Mark to the enemy with the highest health. If it had Mark, repeat this.";
        }
        return "Deal 5 damage to the enemy with the highest health. If it had Mark, repeat this.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 6;
        }
        return 7;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var m = 0;
        var d = 5;
        if (rank == 2)
        {
            m = 1;
            d = 6;
        }
        else if (rank == 3)
        {
            m = 2;
            d = 7;
        }

        var repeat = false;
        do
        {
            var t = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllEnemies());
            if (t == null)
            {
                break;
            }

            repeat = t.HasEffect("mark");
            t.TakeDamage(d);
            t.Particle(BattleManager.Effects.Bullet);
            if (m > 0)
            {
                t.ApplyEffect("mark", m);
            }
            if (repeat)
            {
                t.Particle(BattleManager.Effects.Mark);
            }
        }
        while (repeat);

    }
}
