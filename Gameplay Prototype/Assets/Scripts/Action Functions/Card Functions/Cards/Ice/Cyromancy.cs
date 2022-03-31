/**
// File Name :         Cyromancy.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : Card that deals damage and applies frost to enemies that haven't moved
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyromancy : Card
{
    public override string cardClass()
    {
        return "Cyromancy";
    }

    public override string cardName()
    {
        return "Cryomancy";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 9 damage to an enemy. If they've acted, apply 8 Frost.";
        }

        if (rank == 2)
        {
            return "Deal 7 damage to an enemy. If they've acted apply 6 Frost.";
        }
        return "Deal 6 damage to an enemy. If they've acted, apply 4 Frost.";
    }

    public override string FlavorText()
    {
        return "If you want something to stop moving, this is a comperable alternative to kidnapping";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
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
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 4;
        var d = 6;
        if (rank == 2)
        {
            f = 6;
            d = 7;
        }
        else if (rank == 3)
        {
            f = 8;
            d = 9;
        }

        cb.TakeDamage(d);
        if (cb.HasActed())
        {
            cb.ApplyEffect("frost", f);
            cb.Particle(BattleManager.Effects.Frost);
        }
        cb.Particle(BattleManager.Effects.Slash);
    }
}
