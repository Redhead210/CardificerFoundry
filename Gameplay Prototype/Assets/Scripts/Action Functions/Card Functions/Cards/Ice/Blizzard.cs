/**
// File Name :         Blizzard.cs
// Author :            Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Card that applies damage and frost
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : Card
{
    public override string cardClass()
    {
        return "Blizzard";
    }

    public override string cardName()
    {
        return "Blizzard";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 8 damage. Apply 8 Frost.";
        }

        if (rank == 2)
        {
            return "Deal 6 damage. Apply 6 Frost";
        }

        return "Deal 4 damage. Apply 4 Frost.";
    }

    public override string FlavorText()
    {
        return "Those lawsuits are only pending";//possibly needs reworded
    }
    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override Color cardColor()
    {
        return new Color(0, 0.3f, 0.6f);
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 1;
        }
        return 2;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var e = 4;
        if (rank == 2)
        {
            e = 6;
        }
        if (rank == 3)
        {
            e = 8;
        }

        cb.TakeDamage(e);
        cb.ApplyEffect("frost", e);

        cb.Particle(BattleManager.Effects.Frost);
        cb.Particle(BattleManager.Effects.Punch);
    }
}
