/**
// File Name :         HealingRain.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Heals allies and gives them regen
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRain : Card
{
    public override string cardClass()
    {
        return "HealingRain";
    }

    public override string cardName()
    {
        return "Healing Rain";
    }

    public override string FlavorText()
    {
        return "Like acid rain, but beneficial!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 4 Regen to all allies. They heal equal to their Regen.";
        }
        if (rank == 2)
        {
            return "Apply 4 Regen to all allies.";
        }
        return "Apply 3 Regen to all allies.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 3;
        }
        return 4;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var r = 3;
        if (rank == 2)
        {
            r = 4;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("regen", r);
            if (rank == 3)
            {
                c.Heal(c.EffectStacks("regen"));
            }
            BattleManager.spawnEffect(BattleManager.Effects.Regen, c);
        }
    }
}
