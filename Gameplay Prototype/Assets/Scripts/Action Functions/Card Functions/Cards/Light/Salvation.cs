
/**
// File Name :         Salvation.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Heals allies, and if they are the lowest health, applies block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvation : Card
{
    public override string cardClass()
    {
        return "Salvation";
    }

    public override string cardName()
    {
        return "Salvation";
    }

    public override string FlavorText()
    {
        return "Unfortunately, it's not the eternal version.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Heal an ally for 5. If it's the lowest health ally they gain 12 Block";
        }
        if (rank == 2)
        {
            return "Heal an ally for 3. If it's the lowest health ally they gain 8 Block.";
        }
        return "Heal an ally for 2. If it's the lowest health ally they gain 6 Block.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        return 2;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 2;
        var b = 6;
        if (rank == 2)
        {
            h = 3;
            b = 8;
        }
        if (rank == 3)
        {
            h = 5;
            b = 12;
        }

        cb.Heal(h);
        cb.Particle(BattleManager.Effects.Light);

        if (cb == CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllPlayers()))
        {
            cb.block += b;
            cb.Particle(BattleManager.Effects.Block);
        }


    }
}
