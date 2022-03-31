/**
// File Name :         EmbraceThePain.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : Card that deals deals damage equal to the amount of damage dealt to players
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbraceThePain : Card
{
    public override string cardClass()
    {
        return "EmbraceThePain";
    }

    public override string cardName()
    {
        return "Embrace The Pain";
    }

    public override string FlavorText()
    {
        return "It hurts so good!!!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal damage equal to the party's missing health to all enemies.";
        }
        if (rank == 2)
        {
            return "Deal damage equal to the caster's missing health to all enemies.";
        }
        return "Deal damage equal to the caster's missing health.";
       
    }

    public override int cardSpeed()
    {
        return 7;
    }

    public override Targets cardTarget()
    {
        if (rank != 1)
        {
            return Targets.None;
        }
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        int d = 0;
        if (rank == 3)
        {
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
            {
                d += (c.thisChar.maxhp - c.thisChar.hp);
                c.Particle(BattleManager.Effects.Blood);
            }
        }
        else
        {
            d = caster.thisChar.maxhp - caster.thisChar.hp;
            caster.Particle(BattleManager.Effects.Blood);
        }

        if (rank == 1)
        {
            cb.TakeDamage(d);
            cb.Particle(BattleManager.Effects.Slash);
        }
        else
        {
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
            {
                c.TakeDamage(d);
                c.Particle(BattleManager.Effects.Slash);
            }
        }
    }

}
