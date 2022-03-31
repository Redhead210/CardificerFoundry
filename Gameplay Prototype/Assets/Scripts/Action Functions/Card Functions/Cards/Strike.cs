/**
// File Name :         Strike.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : basic damage dealing card
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : Card
{
    public override string cardClass()
    {
        return "Strike";
    }
    public override string cardName()
    {
        return "Strike";
    }

    public override string FlavorText()
    {
        return "Sometimes the the simplest solution is to just punch a familiar looking goblin.";
    }

    public override string cardDesc()
    {
        if (rank == 1)
        {
            return "Deal 5 damage.";
        }
        return "Deal 6 damage.";
    }

    public override int cardSpeed()
    {
        if (rank == 1)
        {
            return 5;
        }
        return 4;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override Color cardColor()
    {
        return Color.gray;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        if (rank == 1)
        {
            cb.TakeDamage(5);
        }
        else
        {
            cb.TakeDamage(6);
        }

        BattleManager.spawnEffect(BattleManager.Effects.Punch,cb);
    }
}
