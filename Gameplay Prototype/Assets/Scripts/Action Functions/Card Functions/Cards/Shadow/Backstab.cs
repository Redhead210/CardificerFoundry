/**
// File Name :         Backstab.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that deals bonus damage to slow enemies
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backstab: Card
{
    public override string cardClass()
    {
        return "Backstab";
    }
    public override string cardName()
    {
        return "Backstab";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 6 damage. If the target hasn't attack yet, deal 14 instead. Gain 1 Haste.";
        }
        if (rank == 2)
        {
            return "Deal 5 damage. If the target hasn't attack yet, deal 11 instead";
        }

        return "Deal 4 damage. If the target hasn't attacked yet, deal 8 instead.";
    }

    public override int cardSpeed()
    {
        return 2;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }
    public override string FlavorText()
    {
        return "You've gotta be quicker than that!";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override Color cardColor()
    {
        return new Color(0.6f, 0f, 0.6f);
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        var ed = 8;

        if (rank == 2)
        {
            d = 5;
            ed = 11;
        }
        if (rank == 3)
        {
            d = 6;
            ed = 14;
            caster.ApplyEffect("haste", 1);
        }


        var hasAttacked = true;
        foreach (AttackData a in BattleManager.queue)
        {
            if (a.caster == cb)
            {
                hasAttacked = false;
            }
        }

        cb.Particle(BattleManager.Effects.Smoke);
        if (hasAttacked)
        {
            cb.TakeDamage(d);
        }
        else
        {
            cb.TakeDamage(ed,"Shamk!");
            cb.Particle(BattleManager.Effects.Blood);
        }

        cb.Particle(BattleManager.Effects.Slash);
    }
}
