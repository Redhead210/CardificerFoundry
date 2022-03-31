/**
// File Name :         SmokeScreen.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description: applies block and haste to all allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smokescreen : Card
{
    public override string cardClass()
    {
        return "Smokescreen";
    }

    public override string cardName()
    {
        return "Smokescreen";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 3 Haste to all allies. They gain Block equal to twice their Haste.";
        }
        if (rank == 2)
        {
            return "Apply 3 Haste to all allies. They gain Block equal to their Haste.";
        }
        return "Apply 2 Haste to all allies. They gain Block equal to their Haste.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 2;
        }
        return 3;
    }
    public override string FlavorText()
    {
        return "#1: I can't see a thing! #2: Then open your eyes!";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 2;
        var m = 1;
        if (rank == 2)
        {
            h = 3;
        }
        else if (rank == 3)
        {
            m = 2;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("haste", h);
            c.block += c.EffectStacks("haste") * m;
            c.Particle(BattleManager.Effects.Smoke);
            c.Particle(BattleManager.Effects.Blast);
        }
    }
}
