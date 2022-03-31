/**
// File Name :         Medic.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Heals based on Innovate
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : Card
{
    public override string cardClass()
    {
        return "Medic";
    }

    

    public override string cardName()
    {
        return "Medic";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Heal an ally for and give them [" + BattleManager.innovate + "] + 4 Block. Innovate";
        }
        if (rank == 2)
        {
            return "Heal an ally for [" + BattleManager.innovate + "] + 2. Innovate";
        }

        return "Heal an ally for ["+BattleManager.innovate+"]. Innovate";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        return 1;
    }

    public override string FlavorText()
    {
        return "Get some pain meds in ya and get back to fighin'!";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 0;
        if (rank == 2)
        {
            h = 2;
        }
        if (rank == 3)
        {
            h = 4;
            cb.block += h + BattleManager.innovate;
        }

        cb.Heal(h + BattleManager.innovate);
        cb.Particle(BattleManager.Effects.Regen);
        cb.Particle(BattleManager.Effects.Blood);
        cb.Particle(BattleManager.Effects.Cogs);

        BattleManager.innovate++;
        caster.ShowMessage("Innovate [" + BattleManager.innovate + "]", cardColor());
    }
}
