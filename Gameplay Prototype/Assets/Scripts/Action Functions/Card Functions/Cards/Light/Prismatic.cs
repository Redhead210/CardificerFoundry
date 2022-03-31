/**
// File Name :         Prismatic.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : applies radiance and healing
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prismatic : Card
{
    public override string cardClass()
    {
        return "Prismatic";
    }

    public override string cardName()
    {
        return "Prismatic";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 3 Radiance and heal 5";
        }
        if (rank == 2)
        {
            return "Apply 2 Radiance and heal 3.";
        }
        return "Apply 1 Radiance and heal 2.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 3;
        }
        if (rank == 2)
        {
            return 4;
        }
        return 5;
    }

    public override string FlavorText()
    {
        return "You mean to tell me there is a Light side of the moon???";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 2;
        var r = 1;
        if (rank == 2)
        {
            h = 3;
            r = 2;
        }
        else if (rank == 3)
        {
            h = 5;
            r = 3;
        }

        cb.ApplyEffect("radiance", r);
        cb.Heal(h);
        cb.Particle(BattleManager.Effects.Light);
        cb.Particle(BattleManager.Effects.Radience);
    }
}
