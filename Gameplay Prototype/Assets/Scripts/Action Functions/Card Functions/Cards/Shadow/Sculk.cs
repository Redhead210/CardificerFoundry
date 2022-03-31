
/**
// File Name :         Sculk.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage to all enemies, and applies power for all who haven't acted yet
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sculk : Card
{
    public override string cardClass()
    {
        return "Sculk";
    }

    public override string cardName()
    {
        return "Sculk";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain 2 Power for each enemy who hasn't acted yet. Deal 4 damage to all enemies.";
        }

        if (rank == 2)
        {
            return "Gain 1 Power for each enemy who hasn't acted yet. Deal 3 damage to all enemies.";
        }

        return "Gain 1 Power for each enemy who hasn't acted yet. Deal 2 damage to all enemies.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank >= 2)
        {
            return 3;
        }
        return 4;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }
    public override string FlavorText()
    {
        return "Russell, Get out of them bushes!!!";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 2;
        var p = 1;
        if (rank == 2)
        {
            d = 3;
        }
        if (rank == 3)
        {
            d = 4;
            p = 2;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (!c.HasActed())
            {
                caster.ApplyEffect("power", p);
            }
        }

        caster.Particle(BattleManager.Effects.Smoke);
        caster.Particle(BattleManager.Effects.Power);

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.TakeDamage(d);
            c.Particle(BattleManager.Effects.Slash);
        }
    }
}
