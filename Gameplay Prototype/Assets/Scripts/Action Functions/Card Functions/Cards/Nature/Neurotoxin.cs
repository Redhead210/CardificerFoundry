/**
// File Name :         Neurotoxin.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies posion to enemies, and deals damage equal to it

**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neurotoxin : Card
{
    public override string cardClass()
    {
        return "Neurotoxin";
    }

    public override string cardName()
    {
        return "Neurotoxin";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 6 Poison to all enemies. They take damage equal to their Poison.";
        }
        if (rank == 2)
        {
            return "Apply 7 Poison to an enemy. They take damage equal to their Poison.";
        }

        return "Apply 5 Poison to an enemy. They take damage equal to their Poison.";
    }

    public override string FlavorText()
    {
        return "Melty brain juice go BRRRRRRRRR.";
    }

    public override Targets cardTarget()
    {
        if (rank == 3)
        {
            return Targets.None;
        }

        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 5;
        }

        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        if (rank < 3)
        {
            var p = 5;
            if (rank == 2)
            {
                p = 7;
            }

            cb.ApplyEffect("toxin", p);
            cb.TakeDamage(cb.EffectStacks("toxin"));
        }
        else
        {
            foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
            {
                cb.ApplyEffect("toxin", 6);
                cb.TakeDamage(cb.EffectStacks("toxin"));
            }
        }

        cb.Particle(BattleManager.Effects.Toxin);
        cb.Particle(BattleManager.Effects.Slash);
    }
}
