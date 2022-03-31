
/**
// File Name :         RedWoodBash.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Deals damage based on the turn count
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWoodBash : Card

{
    public override string cardClass()
    {
        return "RedWoodBash";
    }

    public override string cardName()
    {
        return "Strong Roots";
    }

    public override string FlavorText()
    {
        return "When the fight has been going just a little too long.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal damage equal to double the amount of turns taken in this battle to all enemies.";
        }
        if (rank == 2)
        {
            return "Deal damage equal to double the amount of turns taken in this battle.";
        }

        return "Deal damage equal to the amount of turns taken in this battle.";
    }

    public override Targets cardTarget()
    {
        if (rank == 3)
        {
            return Targets.None;
        }
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 7;
        }

        return 8;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        int d;

        d = BattleManager.turns;

        if (rank > 1)
        {
            d *= 2;
        }

        if (rank == 3)
        {
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
            {
                c.TakeDamage(d);
            }
        }
        else
        {
            cb.TakeDamage(d);
        }

        cb.Particle(BattleManager.Effects.Punch);
    }
}
