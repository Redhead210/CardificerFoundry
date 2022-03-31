/**
// File Name :         Consecration.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that heals allies and applies radiance
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consecration : Card
{
    public override string cardClass()
    {
        return "Consecration";
    }

    public override string cardName()
    {
        return "Consecration";
    }

    public override string FlavorText()
    {
        return "The power of the Cardificer compels you!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 5 damage to all enemies. All allies heal 5 and gain Radiance.";
        }
        if (rank == 2)
        {
            return "Deal 4 damage to all enemies. All allies heal 4.";
        }
        return "Deal 2 damage to all enemies. All allies heal 2.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }
    

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 2;
        if (rank > 1)
        {
            a += rank;
        }
        
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.Heal(a);
            if (rank == 3)
            {
                c.ApplyEffect("radiance", 1);
            }

            c.Particle(BattleManager.Effects.Regen);
            c.Particle(BattleManager.Effects.Light);
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.TakeDamage(a);

            c.Particle(BattleManager.Effects.Fire);
            c.Particle(BattleManager.Effects.Light);
        }
    }
}
