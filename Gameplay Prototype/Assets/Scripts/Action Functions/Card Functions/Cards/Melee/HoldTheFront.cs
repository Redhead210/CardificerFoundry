/**
// File Name :         HoldTheFront.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies block and heals allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTheFront : Card
{
    public override string cardClass()
    {
        return "HoldTheFront";
    }

    public override string cardName()
    {
        return "Hold The Front";
    }

    public override string FlavorText()
    {
        return "Steady... Steady...";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 8 Block and heal 2 to all allies.";
        }
        if (rank == 2)
        {
            return "Apply 6 Block to all allies.";
        }
        return "Apply 3 Block to all allies.";
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
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var b = 3;
        if (rank == 2)
        {
            b = 6;
        }
        if (rank == 3)
        {
            b = 8;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.block += b;
            if (rank == 3)
            {
                c.Heal(2);
            }
            BattleManager.spawnEffect(BattleManager.Effects.Block, c);
        }
    }


}
