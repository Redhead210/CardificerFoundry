/**
// File Name :         Hemomancy.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Take damage or every enemy, but then dish out more damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hemomancy : Card
{
    public override string cardClass()
    {
        return "Hemomancy";
    }

    public override string cardName()
    {
        return "Hemomancy";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Take 1 damage for each enemy. Deal 10 damage to all enemies.";
        }
        if (rank == 2)
        {
            return "Lose 1 health for each enemy. Deal 8 damage to all enemies.";
        }

        return "Lose 2 health for each enemy. Deal 8 damage to all enemies.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 6;
        }
        return 7;
    }

    public override string FlavorText()
    {
        return "The Law of Equivalent Exchange: Something must be spent to attain a goal. Dark mages jumped to the logical conclusion.";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 2;
        if (rank == 2)
        {
            d = 1;
        }

        caster.Particle(BattleManager.Effects.Blood);
        caster.Particle(BattleManager.Effects.Slash);

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.Particle(BattleManager.Effects.Blast);
            c.Particle(BattleManager.Effects.Smoke);
            if (rank == 3)
            {
                caster.TakeDamage(1);
                c.TakeDamage(10);
            }
            else
            {
                caster.thisChar.hp -= d;
                c.TakeDamage(8);
            }
        }
    }
}
