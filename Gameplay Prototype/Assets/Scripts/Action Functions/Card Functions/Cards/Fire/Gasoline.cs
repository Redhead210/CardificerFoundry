/**
// File Name :         Gasoline.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Adds burn to an enemy, then doubles said burn
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasoline : Card
{
    public override string cardClass()
    {
        return "Gasoline";
    }

    public override string cardName()
    {
        return "Gasoline";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Apply 2 Burn to all enemies, then double their burn.";
        }
        if (rank ==3)
        {
            return "Apply 5 burn to all enemies, then double their burn.";
        }

        return "Apply 1 Burn to all enemies, then double their burn.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 2;
        }

        return 3;
    }
    public override string FlavorText()
    {
        return "BOOM BOOM JUICE!";
    }


    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var b = 1;

        if (rank == 2)
        {
            b = 2;
        }
        else if (rank==3)
        {
            b = 5;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("burn",b);
            c.ApplyEffect("burn", c.EffectStacks("burn"));
            c.Particle(BattleManager.Effects.Fire);
        }
    }
}
