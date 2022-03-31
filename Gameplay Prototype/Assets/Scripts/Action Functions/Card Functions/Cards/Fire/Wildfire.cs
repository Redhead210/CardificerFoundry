/**
// File Name :         Wildfire.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies burn to all enemy equally
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wildfire : Card
{
    public override string cardClass()
    {
        return "Wildfire";
    }

    public override string cardName()
    {
        return "Wildfire";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Apply 4 Burn to an enemy, and spread their Burn to all other enemies.";
        }
        else if (rank==3)
        {
            return "Apply 6 burn to an enemy, and spread their Burn to all other enemies.";
        }
        return "Apply 2 Burn to an enemy, and spread their Burn to all other enemies.";
    }

    public override string FlavorText()
    {
        return "Now with double the collateral damage.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 5;
        }
        else if (rank==3)
        {
            return 3;
        }

        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {

        var b = 2;
        if (rank == 2)
        {
            b = 4;
        }
        else if (rank==3)
        {
            b = 6;
        }

        cb.ApplyEffect("burn", b);

        var a = cb.EffectStacks("burn");

        cb.Particle(BattleManager.Effects.Blast);

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (c != cb)
            {
                c.SetEffect("burn", a);
                
            }
            c.Particle(BattleManager.Effects.Fire);
        }
    }
}
