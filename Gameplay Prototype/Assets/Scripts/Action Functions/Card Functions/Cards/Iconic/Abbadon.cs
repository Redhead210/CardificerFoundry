/**
// File Name :         Abbadon.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Card that kills enemies under a certain health.
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Abbadon : Card
{
    public override string cardClass()
    {
        return "Abbadon";
    }

    public override string cardName()
    {
        return "Abbadon";
    }

    public override string cardDesc()
    {
        var a = 5 * rank;
        if (rank == 3)
        {
            a += 5;
        }
        return "Kill any enemy with less than ["+BattleManager.innovate+"] * "+a+" health.";
    }

    public override string FlavorText()
    {
        return "The Cardificer cast her aside when her role was done. Little did he know, she already stole the one thing he needed.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        return 10;
    }

    public override string Bound()
    {
        return "The Apprentice";
    }

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override Color cardColor()
    {
        return new Color32(80, 60, 90, 255);
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 5 * rank;
        if (rank == 3) { a += 5; }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (c.thisChar.hp < BattleManager.innovate * a)
            {
                c.TakeDamage(9999, "Doomsday.");
                c.Particle(BattleManager.Effects.Blast);
                c.Particle(BattleManager.Effects.Smoke);
                c.Particle(BattleManager.Effects.Cogs);
            }
            else
            {
                c.ShowMessage("Prepare.", cardColor());
            }
        }
    }
}
