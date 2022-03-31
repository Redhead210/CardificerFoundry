/**
// File Name :         Hailstorm.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies frost and deals damage based on the total frost on enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hailstorm : Card
{
    public override string cardClass()
    {
        return "Hailstorm";
    }

    public override string cardName()
    {
        return "Hailstorm";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 6 Frost to an enemy. Deal 2 damage to the highest health enemy for each Frost on all enemies.";
        }
        if (rank == 2)
        {
            return "Apply 6 Frost to an enemy. Deal 1 damage to the highest health enemy for each Frost on all enemies.";
        }
        return "Apply 3 Frost to an enemy. Deal 1 damage to the highest health enemy for each Frost on all enemies.";
    }

    public override string FlavorText()
    {
        return "Like tiny Ice bullets being shot at you from the sky, take cover!!!";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 8;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 3;
        var d = 1;
        if (rank > 1)
        {
            f = 6;
        }
        if (rank == 3)
        {
            d = 2;
        }

        var t = 0;
        cb.Particle(BattleManager.Effects.Frost);
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (c == cb)
            {
                cb.ApplyEffect("frost", f);
            }
            t += c.EffectStacks("frost");
        }

        for (int i = 0; i < t; i++)
        {

            var trg = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllEnemies());
            if (trg == null)
            {
                break;
            }

            trg.TakeDamage(d);
            trg.Particle(BattleManager.Effects.Slash);
        }
    }
}
