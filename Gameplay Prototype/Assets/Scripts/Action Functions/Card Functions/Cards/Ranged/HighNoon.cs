/**
// File Name :         HighNoon.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals  damage on turns which are multiples of six
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighNoon : Card
{
    public override string cardClass()
    {
        return "HighNoon";
    }

    public override string cardName()
    {
        return "High Noon";
    }

    public override string FlavorText()
    {
        return "Gunslingers do their best work between the hours of 11:30am and 12:30pm.";
    }

    public override string cardDesc()
    {
        var s = "";
        if (BattleManager.turns % 6 == 0 || (BattleManager.turns % 5 == 0 && rank == 2) || (BattleManager.turns % 7 == 0 && rank == 3)) {
            s = " (Ready!)";
        }

        if (rank == 3)
        {
            return "Deal 8 damage. If the turn number is a multiple of 5, 6, or 7, deal 24 damage instead."+s;
        }
        if (rank == 2)
        {
            return "Deal 6 damage. If the turn number is a multiple of 5 or 6, deal 24 damage instead."+s;
        }
        return "Deal 6 damage. If the turn number is a multiple of 6, deal 24 damage instead."+s;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 6;
        if (rank == 3)
        {
            d = 8;
        }

        if (BattleManager.turns%6 == 0 || (BattleManager.turns%5==0 && rank == 2) || (BattleManager.turns%7==0 && rank == 3))
        {
            cb.TakeDamage(24, "HIGH NOON!");
        }
        else
        {
            cb.TakeDamage(d);
        }

        cb.Particle(BattleManager.Effects.Bullet);
    }
}
