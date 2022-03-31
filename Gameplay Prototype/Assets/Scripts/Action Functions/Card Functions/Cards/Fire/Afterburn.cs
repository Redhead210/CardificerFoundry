/**
// File Name :         Afterburn.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : card that deals damage and applies burn equal to the damage dealt.
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterburn : Card
{
    public override string cardClass()
    {
        return "Afterburn";
    }

    public override string cardName()
    {
        return "Afterburn";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Deal 6 Damage. Apply Burn equal to the damage dealt.";
        }
        else if(rank ==3)
        {
            return "Deal 9 damage, apply Burn equal to the damage dealt.";
        }

        return "Deal 4 Damage. Apply Burn equal to the damage dealt.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override string FlavorText()
    {
        return "Feels similar to putting on aftershave, but instead of aftershave, it's Greek Fire.";
    }

    public override int cardSpeed()
    {

        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        if (rank == 2)
        {
            d = 6;
        }
        else if (rank == 3)
        {
            d = 9;
        }
            

        cb.ApplyEffect("burn",cb.TakeDamage(d));

        cb.Particle(BattleManager.Effects.Fire);
        cb.Particle(BattleManager.Effects.Slash);
    }
}
