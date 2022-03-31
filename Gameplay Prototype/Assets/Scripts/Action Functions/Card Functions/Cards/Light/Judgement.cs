/**
// File Name :         Judgement.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damage to an enemy, or heals an ally
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : Card
{
    public override string cardClass()
    {
        return "Judgement";
    }

    public override string cardName()
    {
        return "Judgement";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 10 damage to an enemy or restore 8 health to an ally.";
        }
        if (rank == 2)
        {
            return "Deal 8 damage to an enemy or restore 6 health to an ally.";
        }

        return "Deal 6 damage to an enemy or restore 4 health to an ally.";
    }

    public override Targets cardTarget()
    {
        return Targets.Both;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 5;
        }
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override string FlavorText()
    {
        return "\" To Judge them is up to God, to send them to Him is up to me. \"";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 3;
        var d = 6;
        if (rank == 2)
        {
            h = 5;
            d = 8;
        }
        else if (rank == 3)
        {
            h = 8;
            d = 10;
        }

        if (!cb.isEnemy) {
            cb.Heal(h);
            cb.Particle(BattleManager.Effects.Regen);
            cb.Particle(BattleManager.Effects.Light);
        }
        else
        {
            cb.TakeDamage(d);
            cb.Particle(BattleManager.Effects.Light);
            cb.Particle(BattleManager.Effects.Slash);
        }

        
    }
}
