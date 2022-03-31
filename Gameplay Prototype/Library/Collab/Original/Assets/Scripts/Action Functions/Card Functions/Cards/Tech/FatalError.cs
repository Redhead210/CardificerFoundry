using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatalError : Card
{
    public override string cardClass()
    {
        return "FatalError";
    }

    public override string cardName()
    {
        return "Fatal Err0r";
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Deal [" + BattleManager.innovate + "] * 4 to all enemies. Reset your Innovate";
        }
        return "Deal ["+BattleManager.innovate+"] * 3 to all enemies. Reset your Innovate";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 7;
        }
        return 8;
    }
    public override string FlavorText()
    {
        return "Error 404, Entity: \"FlavorText\" Not Found";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 3;
        if (rank == 4)
        {
            d = 4;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.TakeDamage(BattleManager.innovate * d);
        }

        BattleManager.innovate = 0;
    }
}
