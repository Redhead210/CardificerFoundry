/**
// File Name :         NaturesGift.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies regen to allies, or posion to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturesGift : Card
{
    public override string cardClass()
    {
        return "NaturesGift";
    }

    public override string cardName()
    {
        return "Nature's Gift";
    }

    public override string FlavorText()
    {
        return "Mother Nature picks favorites, pray you are one of them.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 6 Regen to all allies and apply 6 Poison to all enemies.";
        }
        if (rank == 2)
        {
            return "Apply 2 Regen to all allies and apply 2 Poison to all enemies.";
        }

        return "Apply 1 Regen to all allies and apply 1 Poison to all enemies.";
    }

    public override Color cardColor()
    {
        return new Color(0, 0.4f, 0f);
    }

    public override int cardSpeed()
    {
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var e = 1;

        if (rank == 2)
        {
            e = 2;
        }
        if (rank == 3)
        {
            e = 3;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("toxin", e);
            c.Particle(BattleManager.Effects.Toxin);
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("regen", e);
            c.Particle(BattleManager.Effects.Regen);
        }

    }
}
