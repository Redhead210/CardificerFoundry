/**
// File Name :         InnerFire.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies burn based on the casters power
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerFire : Card
{
    public override string cardClass()
    {
        return "InnerFire";
    }

    public override string cardName()
    {
        return "Inner Fire";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Gain 3 Power and apply Burn to all enemies equal to twice your Power. Take 1 Damage.";
        }
        if (rank == 2)
        {
            return "Gain 3 Power and apply Burn to all enemies equal to your Power. Take 1 Damage.";
        }
        return "Gain 2 Power and apply Burn to all enemies equal to your Power. Take 1 Damage.";
    }

    public override string FlavorText()
    {
        return "The worst case of Heartburn you've ever had, but good?";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 2;
        var d = 1;
        var m = 1;
        if (rank == 2)
        {
            p = 3;
            d = 2;
        }
        if (rank == 3)
        {
            p = 3;
            d = 4;
            m = 1;
        }

        caster.ApplyEffect("power", p);
        var b = caster.EffectStacks("power");

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("burn",b*m);
            c.Particle(BattleManager.Effects.Fire);
        }
        caster.TakeDamage(1);
        caster.Particle(BattleManager.Effects.Fire);
        caster.Particle(BattleManager.Effects.Power);
    }
}
