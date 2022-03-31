/**
// File Name :         Overclock.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies block and power alongside innovate
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overclock : Card
{

    public override string cardClass()
    {
        return "Overclock";
    }

    public override string cardName()
    {
        return "Overclock";
    }
  


    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply [" + (BattleManager.innovate) + "] + 3 Power and Block. Innovate";
        }

        if (rank == 2)
        {
            return "Apply ["+ (BattleManager.innovate)+"] + 1 Power. Innovate";
        }
        return "Apply ["+ (BattleManager.innovate) + "] Power. Innovate";
    }

    public override string FlavorText()
    {
        return "Crank it up to 11 and break off the knob!";
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

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 0;
        if (rank == 2)
        {
            p = 1;
        }
        if (rank == 3)
        {
            p = 3;
            cb.block += BattleManager.innovate + p;
        }

        if (p+BattleManager.innovate != 0)
        {
            cb.ApplyEffect("power", BattleManager.innovate + p);
        }

        cb.Particle(BattleManager.Effects.Cogs);
        cb.Particle(BattleManager.Effects.Power);

        BattleManager.innovate++;
        caster.ShowMessage("Innovate [" + BattleManager.innovate + "]", cardColor());
    }
}
