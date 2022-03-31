/**
// File Name :         SupriseRound.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies haste to the caster, and deals damage to all players that haven't acted
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupriseRound : Card
{
    public override string cardClass()
    {
        return "SupriseRound";
    }

    public override string cardName()
    {
        return "Surprise Round";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain 2 Haste. Deal 6 damage to an enemy, and to every enemy who hasn't acted.";
        }
        if (rank == 2)
        {
            return "Gain 1 Haste. Deal 5 damage to an enemy, and to every enemy who hasn't acted.";
        }
        return "Gain 1 Haste. Deal 4 damage to an enemy, and to every enemy who hasn't acted.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }
    public override string FlavorText()
    {
        return "Kick out their knees before they can hit you back!";

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
        return CardTypes.Shadow;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        caster.ApplyEffect("haste", 1);

        var d = 4;
        if (rank == 2)
        {
            d = 5;
        }
        if (rank == 3)
        {
            d = 6;
            caster.ApplyEffect("haste", 1);
        }

        cb.TakeDamage(d);
        cb.Particle(BattleManager.Effects.Smoke);
        cb.Particle(BattleManager.Effects.Punch);
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (!c.HasActed())
            {
                c.TakeDamage(d);
                c.Particle(BattleManager.Effects.Smoke);
                c.Particle(BattleManager.Effects.Punch);
            }
        }
    }
}
