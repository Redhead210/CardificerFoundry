/**
// File Name :         Bulwark.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that gains block and taunt
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulwark : Card
{
    public override string cardClass()
    {
        return "Bulwark";
    }

    public override string cardName()
    {
        return "Bulwark";
    }

    public override string FlavorText()
    {
        return "Protect those who cannot protect themselves. That is the warrior's creed.";
    }

    public override string cardDesc()
    {

        if (rank == 3)
        {
            return ("Gain 14 Block and Taunt for two turns.");
        }
        if (rank == 1)
        {
            return "Gain 8 Block and Taunt.";
        }

        return "Gain 10 Block and Taunt.";
        
    }

    public override int cardSpeed()
    {
        if (rank == 1)
        {
            return 3;
        }
        else
        {
            return 2;
        }
    }

    public override CardTypes cardType()
    {
        return CardTypes.Melee;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        if (rank == 1)
        {
            caster.block += 8;
            caster.ApplyEffect("taunt", 1);
        }
        else if (rank == 2)
        {
            caster.block += 10;
            caster.ApplyEffect("taunt", 1);
        }
        else if (rank == 3)
        {
            caster.ApplyEffect("taunt", 2);
            caster.block += 14;
        }

        BattleManager.spawnEffect(BattleManager.Effects.Taunt, caster);
    }
}
