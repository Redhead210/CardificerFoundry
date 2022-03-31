/**
// File Name :         WarningShot.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damage and mark to the target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningShot : Card
{
    public override string cardClass()
    {
        return "WarningShot";
    }
    public override string cardName()
    {
        return "Warning Shot";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 8 Damage. Apply 3 Mark to all enemies.";
        }
        if (rank == 2)
        {
            return "Deal 6 Damage. Apply 3 Mark.";
        }
        return "Deal 4 Damage. Apply 2 Mark.";
    }

    public override string FlavorText()
    {
        return "I said put a shot across their nose, not up it!";
    }

    public override int cardSpeed()
    {
        if(rank == 2)
        {
            return 2;
        }
        return 3;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 2 + (2 * rank);
        var m = 2;
        if (rank > 1)
        {
            m = 3;
        }

        cb.Particle(BattleManager.Effects.Bullet);
        cb.TakeDamage(d);

        if (rank == 3)
        {
            foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
            {
                c.ApplyEffect("mark", m);
                c.Particle(BattleManager.Effects.Mark);
            }
        }
        else
        {
            cb.ApplyEffect("mark", m);
            cb.Particle(BattleManager.Effects.Mark);
        }

        
        cb.Particle(BattleManager.Effects.Mark);
    }
}

