/**
// File Name :         Headshot.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage based on block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headshot : Card
{
    public override string cardClass()
    {
        return "Headshot";
    }

    public override string cardName()
    {
        return "Headshot";
    }

    public override string FlavorText()
    {
        return "1v1 me ScrubLord!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 4 damage to an enemy. Then, if they have no block deal 14 damage and gain 2 Power.";
        }
        if (rank == 2)
        {
            return "Deal 2 damage to an enemy. Then, if they have no block deal 10 damage.";
        }
        return "Deal 3 damage to an enemy. If they have no block deal 9 instead.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 9;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 3;
        var ed = 9;

        cb.Particle(BattleManager.Effects.Bullet);

        if (rank == 2)
        {
            d = 2;
            ed = 10;
        }
        if (rank == 3)
        {
            d = 4;
            ed = 14;
        }

        if (cb.block > 0 || rank <= 2)
        {
            cb.TakeDamage(d);
        }

        if (cb.block == 0)
        {
            cb.Particle(BattleManager.Effects.Mark);
            cb.TakeDamage(ed);
            if (rank == 3)
            {
                caster.ApplyEffect("power", 1);
            }
        }

        
    }
}
