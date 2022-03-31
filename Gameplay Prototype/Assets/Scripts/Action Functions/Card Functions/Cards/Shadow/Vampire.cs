/**
// File Name :         Vampire.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deal damage, then heals based on the damage dealt
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Card
{
    public override string cardClass()
    {
        return "Vampire";
    }

    public override string cardName()
    {
        return "Vampirism";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 5 Damage. Restore Health equal to damage dealt. Gain 2 Power";
        }
        if (rank == 2)
        {
            return "Deal 5 Damage. Restore 4 Health. Gain 1 Power";
        }

        return "Deal 3 Damage. Restore 2 Health. Gain 1 Power";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 4;
        }

        return 5;
    }
    public override string FlavorText()
    {
        return "I vant to zuck your blood!";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 2;
        var d = 3;

        if (rank == 2)
        {
            h = 4;
            d = 5;
        }

        var dmg = cb.TakeDamage(d);

        if (rank == 3)
        {
            h = dmg;
            caster.ApplyEffect("power", 1);
        }

        caster.Heal(h);
        caster.ApplyEffect("power", 1);

        cb.Particle(BattleManager.Effects.Blood);
        cb.Particle(BattleManager.Effects.Slash);

        caster.Particle(BattleManager.Effects.Blood);
        caster.Particle(BattleManager.Effects.Power);
    }
}
