/**
// File Name :         ShieldBash.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage based on the casters block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : Card
{
    public override string cardClass()
    {
        return "ShieldBash";
    }
    public override string cardName()
    {
        return "Shield Bash";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 7 damage. Gain Block equal to twice damage dealt.";

        }
        if (rank == 2)
        {
            return "Deal 6 damage. Gain Block equal to damage dealt.";
        }

        return "Deal 4 damage. Gain Block equal to damage dealt.";
    }

    public override string FlavorText()
    {
        return "The best defense is a good offense!";
    }

    public override int cardSpeed()
    {
        return 4;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        var m = 1;
        if (rank == 2)
        {
            d = 6;
        }
        if (rank == 3)
        {
            m = 2;
            d = 7;
        }

        caster.block += cb.TakeDamage(d) * m;

        BattleManager.spawnEffect(BattleManager.Effects.Block, caster);
        BattleManager.spawnEffect(BattleManager.Effects.Slash, cb);
    }
}
