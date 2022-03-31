/**
// File Name :         IceBlock.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies block, but also Frost
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : Card
{
    public override string cardClass()
    {
        return "IceBlock";
    }

    public override string cardName()
    {
        return "Ice Block";
    }

    public override string FlavorText()
    {
        return "Suprisingly, getting frozen in a block of ice is perfectly harmless, well kinda.";
    }

    public override string cardDesc()
    {

        if (rank == 3)
        {
            return "Gain 12 Block and 1 Frost";
        }
        if (rank == 2)
        {
            return "Gain 10 Block and 2 Frost";
        }
        return "Gain 8 Block and 2 Frost";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 0;
        }
        return 1;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var b = 8;
        var f = 2;
        if (rank == 2)
        {
            b = 10;
        }
        if (rank == 3)
        {
            b = 12;
            f = 1;
        }

        caster.block += b;
        caster.ApplyEffect("frost", f);

        caster.Particle(BattleManager.Effects.Frost);
        caster.Particle(BattleManager.Effects.Block);
    }
}
