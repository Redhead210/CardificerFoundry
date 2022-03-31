
/**
// File Name :         Resilience.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Heals allies and gives them block while applying taunt to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resilience : Card
{
    public override string cardClass()
    {
        return "Resilience";
    }

    public override string cardName()
    {
        return "Resilience";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override string FlavorText()
    {
        return "I'm just thick skinned!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain Taunt. Heal this and an ally for 6 and give them both 6 Block.";
        }
        if (rank == 2)
        {
            return "Gain Taunt. Heal an ally for 5 and give them 5 Block.";
        }
        return "Gain Taunt. Heal an ally for 4 and give them 4 Block.";
    }

    public override Color cardColor()
    {
        return new Color32(128, 103, 82, 255);
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 2;
        }

        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 4;
        if (rank == 2) {
            a = 5;
        }
        if (rank == 3)
        {
            a = 6;
            caster.Heal(a);
            caster.block += a;
        }

        caster.ApplyEffect("taunt", 1);
        cb.Heal(a);
        cb.block += a;

        caster.Particle(BattleManager.Effects.Taunt);
        if (cb != caster)
        {
            cb.Particle(BattleManager.Effects.Block);
        }
        cb.Particle(BattleManager.Effects.Blood);
    }
}
