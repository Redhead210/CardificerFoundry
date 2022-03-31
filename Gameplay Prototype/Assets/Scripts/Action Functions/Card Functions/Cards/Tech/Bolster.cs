/**
// File Name :         Bolster.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that applies extra block with Innovate
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolster : Card
{
    public override string cardClass()
    {
        return "Bolster";
    }

    public override string cardName()
    {
        return "Bolster";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply [" + (BattleManager.innovate) + "] + 8 Block. Innovate twice.";
        }
        if (rank == 2)
        {
            return "Apply [" + (BattleManager.innovate) + "] + 6 Block. Innovate.";
        }

        return "Apply ["+(BattleManager.innovate)+"] + 4 Block. Innovate.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 2;
        }
        return 3;
    }
    public override string FlavorText()
    {
        return "One can never have too much sheet metal strapped to themselves.";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        if (rank == 3)
        {
            cb.block += (8 + BattleManager.innovate);
            BattleManager.innovate++;
        }
        if (rank == 2)
        {
            cb.block += (6 + BattleManager.innovate);
        }
        else
        {
            cb.block += 4 + BattleManager.innovate;
        }

        BattleManager.innovate++;

        cb.Particle(BattleManager.Effects.Cogs);
        cb.Particle(BattleManager.Effects.Block);

        caster.ShowMessage("Innovate [" + BattleManager.innovate + "]", cardColor());
    }
}
