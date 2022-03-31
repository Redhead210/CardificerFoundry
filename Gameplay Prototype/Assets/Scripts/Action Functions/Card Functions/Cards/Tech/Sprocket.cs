/**
// File Name :         Sprocket.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage, and innovates based on the casters power
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprocket : Card
{
    public override string cardClass()
    {
        return "Sprocket";
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override string cardName()
    {
        return "Sprocket";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 6 Damage. Innovate equal to this character's Power. Gain 3 Power.";
        }
        if (rank == 2)
        {
            return "Deal 4 Damage. Innovate equal to this character's Power. Gain 1 Power.";
        }
        return "Deal 4 Damage. Innovate equal to this character's Power.";
    }

    public override string FlavorText()
    {
        return "Kind of looks like a saw blade, doesn't it?";
    }
    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 0;
        var d = 4;
        if (rank == 2)
        {
            p = 1;
        }
        else if (rank == 3)
        {
            p = 3;
            d = 6;
        }

        cb.TakeDamage(d);

        BattleManager.innovate += caster.EffectStacks("power");
        caster.ShowMessage("Innovate [" + BattleManager.innovate + "]", cardColor());

        if (p > 0)
        {
            caster.ApplyEffect("power", p);
        }

        caster.Particle(BattleManager.Effects.Cogs);
        caster.Particle(BattleManager.Effects.Power);

        cb.Particle(BattleManager.Effects.Cogs);
        cb.Particle(BattleManager.Effects.Slash);
    }
}
