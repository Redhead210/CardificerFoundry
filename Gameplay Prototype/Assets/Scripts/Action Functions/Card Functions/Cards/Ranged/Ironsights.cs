/**
// File Name :         Ironsights.cs
// Author :            Will Bennington,Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies mark to target, and power to caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ironsights : Card
{
    public override string cardClass()
    {
        return "Ironsights";
    }
    public override string cardName()
    {
        return "Ironsights";
    }

    public override string FlavorText()
    {
        return "Yes, we know that's a scope retical.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 6 Mark. Gain 2 Power.";

        }
        return "Apply 4 Mark.";
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 1;
        }
        return 2;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var m = 4;
        if (rank == 3)
        {
            m = 6;
            cb.ApplyEffect("power", 2);
        }
        cb.ApplyEffect("mark", m);

        cb.Particle(BattleManager.Effects.Mark);
    }
}
