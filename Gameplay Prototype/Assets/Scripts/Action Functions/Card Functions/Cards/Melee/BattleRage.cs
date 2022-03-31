/**
// File Name :         BattleRage.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that applies taunt and gains power
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRage : Card
{
    public override string cardClass()
    {
        return "BattleRage";
    }

    public override string cardName()
    {
        return "Battle Rage";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain Taunt, 2 Power and 2 Block for each attacking enemy. Gain 4 Block.";
        }
        if (rank == 2)
        {
            return "Gain Taunt and 1 Power for each attacking enemy. Gain 4 Block.";
        }

        return "Gain Taunt and 1 Power for each attacking enemy.";
    }

    public override Color cardColor()
    {
        return new Color32(128, 103, 82, 255);
    }

    public override int cardSpeed()
    {
        return 1;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override string FlavorText()
    {
        return "RRRRRAAAAAAGGGHHH! PUNY CARDIFICER!!!";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 1;
        if (rank >= 2)
        {
            caster.block += 4;
        }
        if (rank == 3)
        {
            p = 2;
        }


        caster.ApplyEffect("Taunt", 1);

        var i = 0;
        foreach (AttackData a in BattleManager.queue)
        {
            if (a.caster.isEnemy && a.caster != null && a.caster.isEnemy)
            {
                i += p;
                if (rank == 3)
                {
                    caster.block += 3;
                }
            }
        }

        if (i > 0)
        {
            caster.ApplyEffect("power",i);
        }

        BattleManager.spawnEffect(BattleManager.Effects.Taunt, caster);
        BattleManager.spawnEffect(BattleManager.Effects.Power, caster);
    }
}
