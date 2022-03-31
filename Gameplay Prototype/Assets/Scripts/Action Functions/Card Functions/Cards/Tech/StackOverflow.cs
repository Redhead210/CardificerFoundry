/**
// File Name :         StackOverflow.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damge based on all the status effects in play
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackOverflow : Card
{
    public override string cardClass()
    {
        return "StackOverflow";
    }

    public override string cardName()
    {
        return "Stack Overflow";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal damage to all enemies equal to the total status effects on all characters.";
        }
        if (rank == 2)
        {
            return "Deal damage to an enemy equal to the total status effects on all characters.";
        }
        return "Deal damage to an enemy equal to the total status effects on all enemies.";
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override string FlavorText()
    {
        return "Oh God! Why are so many red Squiggles?!?!";
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
        return 7;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        CharacterBehaviour[] l;
        if (rank == 1)
        {
            l = CharacterBehaviour.getAllEnemies();
        }
        else
        {
            l = CharacterBehaviour.getAllAlive();
        }

        var d = 0;
        foreach(CharacterBehaviour c in l)
        {
            foreach(StatusEffect s in c.statusEffects)
            {
                d += s.stacks;
            }
        }

        if (rank == 3)
        {
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
            {
                c.TakeDamage(d);
                c.Particle(BattleManager.Effects.Blast);
                c.Particle(BattleManager.Effects.Smoke);
                c.Particle(BattleManager.Effects.Cogs);
            }
        }
        else
        {
            cb.TakeDamage(d);
            cb.Particle(BattleManager.Effects.Blast);
            cb.Particle(BattleManager.Effects.Smoke);
            cb.Particle(BattleManager.Effects.Cogs);
        }
        
    }
}
