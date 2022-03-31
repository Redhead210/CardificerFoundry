/**
// File Name :         CounterStrike.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : A card that deals damage to enemies that haven't acted yet, and applies block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterStrike : Card
{
    public override string cardClass()
    {
        return "CounterStrike";
    }

    public override string cardName()
    {
        return "Counter-Strike";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain Taunt. Deal 7 damage to all who haven't acted yet. Gain 5 Block for each.";
        }
        if (rank == 2)
        {
            return "Gain Taunt. Deal 5 damage to all who haven't acted yet. Gain 3 Block for each.";
        }

        return "Gain Taunt. Deal 5 damage to all enemies who haven't acted yet.";
    }

    public override Color cardColor()
    {
        return new Color32(128, 103, 82, 255);
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 2;
        }
        return 4;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override string FlavorText()
    {
        return "Time to go on the offense... globally";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {

        var d = 5;
        var b = 0;
        if (rank == 2)
        {
            b = 3;
        }
        if (rank == 3)
        {
            d = 7;
            b = 5;
        }

        caster.ApplyEffect("taunt", 1);
        foreach(AttackData a in BattleManager.queue)
        {
            if (a.caster.isEnemy && a.caster != null && a.caster.isEnemy)
            {
                a.caster.TakeDamage(d);
                caster.block += b;
                BattleManager.spawnEffect(BattleManager.Effects.Slash, a.caster);
            }
        }

        BattleManager.spawnEffect(BattleManager.Effects.Taunt, caster);
    }
}
