/**
// File Name :        Ichor.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage to all enemies, and heals all allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ichor : Card
{
    public override string cardClass()
    {
        return "Ichor";
    }

    public override string cardName()
    {
        return "Ichor";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 4 damage to all enemies. Restore damage dealt to an all allies";
        }
        if (rank == 2)
        {
            return "Deal 3 damage to all enemies. Restore damage dealt to an ally.";
        }
        return "Deal 2 damage to all enemies. Restore damage dealt to an ally.";
    }

    public override string FlavorText()
    {
        return "The Blood of the Ancient One: high in Vitimin C!";
    }

    public override Targets cardTarget()
    {
        if (rank == 3)
        {
            return Targets.None;
        }
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        return 6;
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
            d = 3;
        }
        if (rank == 3)
        {
            d = 4;
        }

        var h = 0;
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            h += c.TakeDamage(d);
            c.Particle(BattleManager.Effects.Blood);
            c.Particle(BattleManager.Effects.Slash);
        }

        if (rank == 3)
        {
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
            {
                c.Heal(h);
                c.Particle(BattleManager.Effects.Blood);
            }
        }
        else
        {
            cb.Heal(h);
            cb.Particle(BattleManager.Effects.Blood);
        }
    }
}
