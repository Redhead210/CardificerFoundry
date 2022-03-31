/**
// File Name :         OathKeeperPath.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : A card Specific to the Oathkeepers
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OathkeeperPath : Card
{
    public override string cardClass()
    {
        return "OathkeeperPath";
    }

    public override string cardName()
    {
        return "Onslaught";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 10 Damage to an enemy. Apply Burn and heal all allies equal to half damage dealt.";
        }
        if (rank == 2)
        {
            return "Deal 6 Damage to an enemy. Apply Burn and heal all allies equal to damage dealt.";
        }
        return "Deal 4 Damage to an enemy. Apply Burn and heal all allies equal to damage dealt.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override string Bound()
    {
        return "The Oathkeeper";
    }

    public override int cardSpeed()
    {
        return 7;
    }

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override string FlavorText()
    {
        return "After decades sworn to peace, violence became his only option.\nA good leader leads by example.";
    }

    public override Color cardColor()
    {
        return new Color32(255, 199, 102, 255);
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 2 + (2 * rank);

        var e = Mathf.CeilToInt(cb.TakeDamage(d));

        cb.ApplyEffect("burn", e);
        cb.Particle(BattleManager.Effects.Blast);
        cb.Particle(BattleManager.Effects.Fire);
        cb.Particle(BattleManager.Effects.Slash);

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.Heal(e);
            c.Particle(BattleManager.Effects.Light);
        }
    }
}
