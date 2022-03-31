/**
// File Name :         Invigorate.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Gives allies power
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invigorate : Card
{
    public override string cardClass()
    {
        return "Invigorate";
    }

    public override string cardName()
    {
        return "Invigorate";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain and give an ally 5 Power.";
        }
        if (rank == 2)
        {
            return "Give an ally 4 Power.";
        }

        return "Give an ally 2 Power.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        return 1;
    }

    public override string FlavorText()
    {
        return "don't consume more than four of these cards, lest you risk heart disease.";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 2;
        if (rank == 2)
        {
            p = 4;
        }
        if (rank == 3)
        {
            p = 5;
            caster.ApplyEffect("power", p);
            caster.Particle(BattleManager.Effects.Power);
        }

        cb.ApplyEffect("power",p);

        cb.Particle(BattleManager.Effects.Power);
    }
}
