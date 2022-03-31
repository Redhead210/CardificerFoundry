/**
// File Name :         Defend.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Applies block to allies or the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Card
{
    public override string cardClass()
    {
        return "Defend";
    }

    public override string cardName()
    {
        return "Defend";
    }

    public override string FlavorText()
    {
        return "Wait, when did they get that shield?";
    }

    public override string cardDesc()
    {
        if (rank == 1)
        {
            return "Apply 5 Block";
        }
        return "Apply 7 Block.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override Color cardColor()
    {
        return Color.grey;
    }

    public override int cardSpeed()
    {
        if (rank == 1)
        {
            return 3;
        }
        return 2;
    }
    

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        if (rank == 1)
        {
            cb.block += 5;
        }
        else
        {
            cb.block += 7;
        }

        BattleManager.spawnEffect(BattleManager.Effects.Block, cb);
    }


}
