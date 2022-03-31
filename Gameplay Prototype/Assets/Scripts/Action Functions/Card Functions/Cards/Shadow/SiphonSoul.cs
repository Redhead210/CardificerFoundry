/**
// File Name :         SiphonSoul.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deal damage and heals the caster equal to the unblocked damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiphonSoul : Card
{
    public override string cardClass()
    {
        return "SiphonSoul";
    }

    public override string cardName()
    {
        return "Siphon Soul";
    }

    public override string FlavorText()
    {
        return "The soul is the essense of life. Dark magic tends to use this knowledge in \"creative ways.\"";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 7 damage. Heal equal to double unblocked damage dealt.";
        }

        if (rank == 2)
        {
            return "Deal 6 damage. Heal equal to unblocked damage dealt.";
        }

        return "Deal 4 damage. Heal equal to unblocked damage dealt.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 3;
        }
        return 4;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var m = 1;
        var d = 4;
        if (rank == 2)
        {
            d = 6;
        }
        else if (rank == 3)
        {
            d = 7;
            m = 2;
        }


        var h = cb.TakeDamage(d);
        caster.Heal(h*m);
        caster.Particle(BattleManager.Effects.Blood);
        cb.Particle(BattleManager.Effects.Smoke);
    }
}
