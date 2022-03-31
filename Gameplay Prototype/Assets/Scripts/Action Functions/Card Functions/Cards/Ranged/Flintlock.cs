/**
// File Name :         Flintlock.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : A card that deals damage and applies mark
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flintlock : Card
{
    public override string cardClass()
    {
        return "Flintlock";
    }
    public override string cardName()
    {
        return "Flintlock";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 6 damage. If the character has Mark gain 3 Power. Apply 3 Mark.";
        }
        if (rank == 2)
        {
            return "Deal 4 damage. If the character has Mark gain 1 Power. Apply 1 Mark.";
        }
        return "Deal 4 damage. If the character has Mark gain 1 Power.";
    }

    public override int cardSpeed()
    {
        return 4;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override string FlavorText()
    {
        return "We'll beat you with the power of friendship, love, and this gun I found!";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        var p = 1;
        if (rank == 3)
        {
            d = 6;
            p = 3;
        }

        if (cb.HasEffect("Mark"))
        {
            caster.ApplyEffect("power", p);
        }

        cb.Particle(BattleManager.Effects.Bullet);
        cb.TakeDamage(d);

        if (rank == 2)
        {
            cb.ApplyEffect("mark", 1);
        }
        else if (rank == 3)
        {
            cb.ApplyEffect("mark", 3);
        }

    }
}
