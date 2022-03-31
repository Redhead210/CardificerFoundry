/**
// File Name :         LaserBeam.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies radiance to allies, and then deals damage to enemies based on that
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : Card
{
    public override string cardClass()
    {
        return "LaserBeam";
    }

    public override string cardName()
    {
        return "Laser Beam";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 3 Radiance to allies. Deal damage to an enemy equal to all ally's radiance.";
        }
        if (rank == 2)
        {
            return "Apply 2 Radiance to all allies. Deal damage to an enemy equal to all ally's radiance.";
        }

        return "Apply 1 Radiance to all allies. Deal damage to an enemy equal to all ally's radiance.";
    }

    public override string FlavorText()
    {
        return "Who is Wilhelm and why is he screaming?";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 7;
        }
        return 8;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var r = rank;

        var c = 0;
        foreach (CharacterBehaviour ch in CharacterBehaviour.getAllPlayers())
        {
            ch.ApplyEffect("radiance",r);
            c += ch.EffectStacks("radiance");
            ch.Particle(BattleManager.Effects.Light);
        }

        cb.TakeDamage(c);
        cb.Particle(BattleManager.Effects.Blast);
    }
}
