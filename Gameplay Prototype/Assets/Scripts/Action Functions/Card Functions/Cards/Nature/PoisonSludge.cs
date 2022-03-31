/**
// File Name :         PosionSludge.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damage and toxin
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSludge : Card
{
    public override string cardClass()
    {
        return "PoisonSludge";
    }
    public override string cardName()
    {
        return "Poison Sludge";
    }

    public override string FlavorText()
    {
        return "You're really just flinging leftover refried beans at them, but they don't know that.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 4 damage and apply 6 Poison to all enemies.";
        }
        if (rank == 2)
        {
            return "Deal 2 damage and apply 3 Poison to all enemies.";
        }
        return "Apply 3 Poison to all enemies.";
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 2;
        }
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override Color cardColor()
    {
        return new Color (0f, 0.4f, 0f );
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 3;
        var d = 0;
        if (rank == 2)
        {
            d = 2;
        }
        if (rank == 3)
        {
            p = 6;
            d = 4;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (d > 0)
            {
                c.TakeDamage(d);
            }

            c.ApplyEffect("toxin", p);

            c.Particle(BattleManager.Effects.Toxin);
        }
    }
}
