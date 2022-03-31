/**
// File Name :         ActOfMercy.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that deals damage but can't kill the target
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActOfMercy : Card
{
    public override string cardClass()
    {
        return "ActOfMercy";
    }

    public override string cardName()
    {
        return "Act Of Mercy";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 15 damage to an enemy. Their health can't drop below 1.";
        }
        if (rank == 2)
        {
            return "Deal 10 damage to an enemy. Their health can't drop below 2.";
        }
        return "Deal 10 damage to an enemy. Their health can't drop below 4.";
    }

    public override string FlavorText()
    {
        return "* Disclaimer: If your Mercy last more than 4 turns, please consult your local healer";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 5;
        }
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 10;
        var m = 4;
        if (rank == 2)
        {
            m = 2;
        }
        if (rank == 3)
        {
            d = 15;
            m = 1;
        }

        var msg = "";
        if (d >= cb.thisChar.hp)
        {
            cb.Particle(BattleManager.Effects.Blood);
            msg = "Spared.";
        }

        cb.TakeDamage(d, msg);
        cb.thisChar.hp = Mathf.Max(m, cb.thisChar.hp);

        cb.Particle(BattleManager.Effects.Punch);
        cb.Particle(BattleManager.Effects.Light);
    }
}
