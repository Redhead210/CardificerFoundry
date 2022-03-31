/**
// File Name :         Dash.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : deals damage to an enemy based on the haste level of the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Card
{
    public override string cardClass()
    {
        return "Dash";
    }

    public override string cardName()
    {
        return "Dash";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 4 plus this character's haste to an enemy. Gain 3 Haste.";
        }
        if (rank == 2)
        {
            return "Deal 3 plus this character's haste to an enemy. Gain 2 Haste.";
        }
        return "Deal 3 plus this character's haste to an enemy. Gain 1 Haste.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 4;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override string FlavorText()
    {
        return "I'm faster, stronger, and better looking too!";
    }
    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 1;
        var b = 3;
        if (rank == 2)
        {
            d = 2;
        }
        if (rank == 3)
        {
            b = 4;
            d = 3;
        }

        cb.TakeDamage(b + caster.EffectStacks("haste"));
        caster.ApplyEffect("haste", d);
        cb.Particle(BattleManager.Effects.Punch);
        caster.Particle(BattleManager.Effects.Smoke);
    }
}
