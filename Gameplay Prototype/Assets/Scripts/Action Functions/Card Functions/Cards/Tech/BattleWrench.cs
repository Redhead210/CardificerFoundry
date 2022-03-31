/**
// File Name :         BattleWrench.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that deals extra damage based on Innovate
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWrench : Card
{
    public override string cardClass()
    {
        return "BattleWrench";
    }

    public override string cardName()
    {
        return "Battle Wrench";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 8 +[" + BattleManager.innovate + "]. Innovate twice.";
        }
        if (rank == 2)
        {
            return "Deal 6 + [" + BattleManager.innovate + "]. Innovate.";
        }
        return "Deal 4 + ["+BattleManager.innovate+"]. Innovate.";
    }
    public override string FlavorText()
    {
        return "That which can create, can also destroy.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 4;
        }
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        var i = 1;
        if (rank == 2)
        {
            d = 6;
        }
        if (rank == 3)
        {
            d = 7;
            i = 2;
        }

        cb.TakeDamage(d+BattleManager.innovate);
        BattleManager.innovate += i;

        cb.Particle(BattleManager.Effects.Cogs);
        cb.Particle(BattleManager.Effects.Punch);

        caster.ShowMessage("Innovate [" + BattleManager.innovate + "]", cardColor());
        
    }
}
