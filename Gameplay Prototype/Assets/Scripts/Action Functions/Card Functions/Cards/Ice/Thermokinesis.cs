/**
// File Name :         Thermokinesis.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage based on the frost applied to an enemy, then removes the frost
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermokinesis : Card
{
    public override string cardClass()
    {
        return "Thermokinesis";
    }

    public override string cardName()
    {
        return "Thermokinesis";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal damage to an enemy equal to the Frost of all enemies plus 8. Remove Frost from all enemies.";
        }
        if (rank == 2)
        {
            return "Deal damage to an enemy equal to the Frost of all enemies plus 5. Remove Frost from all enemies.";
        }
        return "Deal damage to an enemy equal to the Frost of all enemies. Remove Frost from all enemies.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 6;
        }
        if (rank == 2)
        {
            return 7;
        }
        return 8;
    }
    public override string FlavorText()
    {
        return "The fourth law of thermodynamics is \" I do what I want\".";
    }


    public override bool SynergyCard()
    {
        return true;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 0;
        if (rank == 2)
        {
            f = 5;
        }


        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            f += c.EffectStacks("frost");
            c.RemoveEffect("frost");
        }

        cb.Particle(BattleManager.Effects.Frost);
        cb.Particle(BattleManager.Effects.Blast);

        cb.TakeDamage(f);
    }
}
