/**
// File Name :         Divinity.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : applies block and radiance to allies 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divinity : Card
{
    public override string cardClass()
    {
        return "Divinity";
    }

    public override string cardName()
    {
        return "Divinity";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 3 radiance to ally. They gain Block equal to three times their Radiance.";
        }
        if (rank == 2)
        {
            return "Apply 3 radiance to an ally. They gain Block equal to twice their Radiance.";
        }
        return "Apply 2 radiance to an ally. They gain Block equal to twice their Radiance.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 2;
        }
        if (rank == 2)
        {
            return 3;
        }
        return 4;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }
    public override string FlavorText()
    {
        return "Consider yourself (for the time being) a god amongst men!";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var r = 2;
        var m = 2;
        if (rank == 2)
        {
            r = 3;
        }
        if (rank == 3)
        {
            r = 3;
            m = 3;
        }

        cb.ApplyEffect("radiance", r);
        cb.block += m * cb.EffectStacks("radiance");

        cb.Particle(BattleManager.Effects.Block);
        cb.Particle(BattleManager.Effects.Radience);
    }
}
