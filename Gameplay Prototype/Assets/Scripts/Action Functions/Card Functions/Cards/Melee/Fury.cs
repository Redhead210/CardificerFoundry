/**
// File Name :         Fury.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Deals 1 damage a series of times
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fury : Card
{
    public override string cardClass()
    {
        return "Fury";
    }

    public override string cardName()
    {
        return "Fury";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 1 Damage 5 Times. Gain 2 Power";
        }
        if (rank == 2)
        {
            return "Deal 1 Damage 5 Times. Gain 1 Power";
        }

        return "Deal 1 Damage 3 Times. Gain 1 Power.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 4;
        }
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override string FlavorText()
    {
        return "Hell hath no fury like a Cardificer scorned.";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 3;
        var p = 1;
        if (rank == 2)
        {
            a = 5;
        }
        if (rank == 3)
        {
            p = 2;
        }

        for (int i = 0; i < a; i++) {
            cb.TakeDamage(1);
        }

        caster.ApplyEffect("power", p);

        caster.Particle(BattleManager.Effects.Power);
        cb.Particle(BattleManager.Effects.Punch);
        cb.Particle(BattleManager.Effects.Slash);
    }
}
