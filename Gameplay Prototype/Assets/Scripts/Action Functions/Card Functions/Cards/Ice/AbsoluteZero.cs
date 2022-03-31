/**
// File Name :         AbsoluteZero.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that deals damage based on Frost
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteZero : Card
{
    public override string cardClass()
    {
        return "AbsoluteZero";
    }

    public override string cardName()
    {
        return "Absolute Zero";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 10 Frost to all enemies.";
        }
        if (rank == 2)
        {
            return "Apply 8 Frost to all enemies";
        }
        return "Apply 5 Frost to all enemies.";
    }


    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 1;
        }
        if (rank == 2)
        {
            return 2;
        }
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override string FlavorText()
    {
        return "[Insert Austrian BodyBuilder quote here]";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 5;
        if (rank == 2)
        {
            f = 8;
        }
        else if (rank == 3)
        {
            f = 10;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("frost", f);
            c.Particle(BattleManager.Effects.Frost);
        }
    }
}
