/**
// File Name :         LifeFindsAWay.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Heals a percentage of an Ally's health
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeFindsAWay : Card
{
    public override string cardClass()
    {
        return "LifeFindsAWay";
    }

    public override string cardName()
    {
        return "Rejuvinate";
    }

    public override string FlavorText()
    {
        return "Some say it restores one's very soul. Turns out the soul is worth about half your max HP, whod've thunk?";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Heals one half of an ally's max hp.";
        }
        if (rank == 2)
        {
            return "Heals one half of the casters max hp.";
        }

        return "Heals one quarter of the casters max hp.";
    }

    public override Targets cardTarget()
    {
        if (rank == 3)
        {
            return Targets.Players;
        }
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 2;
        }

        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        int h;

        var t = caster;
        if (rank == 3)
        {
            t = cb;
        }

        if (rank>=2)
        {
            h = t.thisChar.maxhp / 2;
        }
        else
        {
            h = t.thisChar.maxhp / 4;
        }

        t.Heal(h);

        BattleManager.spawnEffect(BattleManager.Effects.Regen, t);
    }
}
