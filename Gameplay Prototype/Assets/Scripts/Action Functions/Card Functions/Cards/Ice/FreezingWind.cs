/**
// File Name :         FreezingWind.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Applies the same amount of frost and damage to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingWind : Card
{
    public override string cardClass()
    {
        return "FreezingWind";
    }

    public override string cardName()
    {
        return "Freezing Wind";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 5 Frost to all enemies. They take damage equal to their Frost.";
        }
        if (rank == 2)
        {
            return "Apply 3 Frost to all enemies. They take damage equal to their Frost.";
        }
        return "Apply 2 Frost to all enemies. They take damage equal to their Frost.";
    }

    public override string FlavorText()
    {
        return "Tepid Wind just wasn't as effective.";
    }

    public override Color cardColor()
    {
        return new Color(0, 0.3f, 0.6f);
    }

    public override int cardSpeed()
    {
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 2;
        if (rank == 2)
        {
            f = 3;
        }
        else if (rank == 3)
        {
            f = 5;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("frost", f);
            c.TakeDamage(c.EffectStacks("frost"));
            c.Particle(BattleManager.Effects.Frost);
            c.Particle(BattleManager.Effects.Slash);
        }
    }
}
