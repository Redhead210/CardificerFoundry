/**
// File Name :         CircleOfLife.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : Card that heals and regens an ally, or poisons and damages an enemy
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOfLife : Card
{
    public override string cardClass()
    {
        return "CircleOfLife";
    }
    public override string cardName()
    {
        return "Circle Of Life";
    }
    public override string FlavorText()
    {
        return "Opposeed to the Rectangle of death, which is just a C4 charge.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 10 Regeneration and heal 2 to an ally and or 10 Poison and 2 damage to an enemy.";
        }
        if (rank == 2)
        {
            return "Apply 8 Regeneration to an ally or 8 Poison to an enemy.";
        }
        return "Apply 6 Regeneration to an ally or 6 Poison to an enemy.";
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 3;
        }
        return 4;
    }

    public override Targets cardTarget()
    {
        return Targets.Both;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override Color cardColor()
    {
        return new Color(0f, 0.4f, 0f);
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 6;
        if (rank == 2)
        {
            a = 8;
        }
        if (rank == 3)
        {
            a = 10;
        }

        if (cb.isEnemy)
        {
            cb.ApplyEffect("toxin", a);
            if (rank == 3)
            {
                cb.TakeDamage(2);
            }
            BattleManager.spawnEffect(BattleManager.Effects.Toxin, cb);
        }
        else
        {
            cb.ApplyEffect("regen", a);
            if (rank == 3)
            {
                cb.Heal(2);
            }
            BattleManager.spawnEffect(BattleManager.Effects.Regen, cb);
        }
    }
}
