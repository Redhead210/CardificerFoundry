/**
// File Name :         BlastWave.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that deals damage to all enemies
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : Card
{
    public override string cardClass()
    {
        return "BlastWave";
    }

    public override string cardName()
    {
        return "Blast Wave";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 8 Damage and apply 2 Burn to all enemies.";
        }
        if (rank == 2)
        {
            return "Deal 6 Damage to all enemies.";
        }
        return "Deal 3 Damage to all enemies.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override string FlavorText()
    {
        return "Do the words 5 mile island mean anything to you?";
    }

    public override int cardSpeed()
    {
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 3;
        if (rank == 2)
        {
            d = 6;
        }
        if (rank == 3)
        {
            d = 8;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.TakeDamage(d);
            c.Particle(BattleManager.Effects.Blast);
            if (rank == 3)
            {
                c.ApplyEffect("burn", 2);
            }
        }
    }
}
