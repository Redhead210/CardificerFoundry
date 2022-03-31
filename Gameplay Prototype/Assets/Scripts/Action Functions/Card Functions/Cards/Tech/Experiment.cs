/**
// File Name :         Experiment.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : deals a random effect
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment : Card
{
    public override string cardClass()
    {
        return "Experiment";
    }

    public override string cardName()
    {
        return "Experiment";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Triple a character's status effects. Innovate.";
        }
        if (rank == 2)
        {
            return "Double a character's status effects. Innovate.";
        }
        return "Double a character's status effects.";
    }

    public override Targets cardTarget()
    {
        return Targets.Both;
    }

    public override int cardSpeed()
    {
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var m = 1;
        if (rank == 3)
        {
            m = 2;
        }

        foreach(StatusEffect s in cb.statusEffects)
        {
            cb.ApplyEffect(s.name, s.stacks*m);
        }

        if (rank > 1)
        {
            BattleManager.innovate++;
        }

        cb.Particle(BattleManager.Effects.Blast);
        cb.Particle(BattleManager.Effects.Cogs);
    }
}
