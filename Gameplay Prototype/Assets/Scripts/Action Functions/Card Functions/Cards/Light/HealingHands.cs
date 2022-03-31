/**
// File Name :         HealingHands.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Heals allies for a certain amount
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHands : Card
{
    public override string cardClass()
    {
        return "HealingHands";
    }

    public override string cardName()
    {
        return "Healing Touch";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Heal an ally for 12.";
        }
        if (rank == 2)
        {
            return "Heal an ally for 8.";
        }
        return "Heal an ally for 6.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override string FlavorText()
    {
        return "Physical contact isn't actually required, Paladins are just touch starved.";
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 3;
        }
        if (rank == 2)
        {
            return 4;
        }
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 6;
        if (rank == 2)
        {
            h = 8;
        }
        if (rank == 3)
        {
            h = 12;
        }

        cb.Particle(BattleManager.Effects.Regen);
        cb.Particle(BattleManager.Effects.Light);

        cb.Heal(h);
    }
}
