/**
// File Name :         ArmorUp.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that applies block every turn
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUp : Card
{
    public override string cardClass()
    {
        return "ArmorUp";
    }

    public override string cardName()
    {
        return "Armor Up";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain 5 Block. At the start of each turn gain 5 Block.";
        }
        if (rank == 2)
        {
            return "Gain 3 Block. At the start of each turn gain 3 Block.";
        }
        return "At the start of each turn gain 2 Block.";
    }

    public override string FlavorText()
    {
        return "The goblins might not be able to break your armor, but they can hurt you emotionally";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        return 2;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 2;
        var b = 0;
        if (rank == 2)
        {
            b = 3;
            a = 3;
        }
        if (rank == 3)
        {
            b = 5;
            a = 5;
        }


        caster.block += b;

        caster.ApplyEffect("armor", a);

        BattleManager.spawnEffect(BattleManager.Effects.Block, caster);
        BattleManager.spawnEffect(BattleManager.Effects.Power, caster);
    }
}
