/**
// File Name :         Flare.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Appplies mark to all enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : Card
{
    public override string cardClass()
    {
        return "Flare";
    }

    public override string cardName()
    {
        return "Flare";
    }

    public override string FlavorText()
    {
        return "HEY, OVER HERE!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 3 Mark to all enemies. Apply 1 Power to all allies.";
        }
        if (rank == 2)
        {
            return "Apply 2 Mark to all enemies.";
        }

        return "Apply Mark to all enemies";
    }

    public override Targets cardTarget()
    {
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
        return CardTypes.Ranged;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var e = rank;

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("mark", e);
            c.Particle(BattleManager.Effects.Mark);
        }

        if (rank == 3)
        {
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
            {
                c.ApplyEffect("power", 1);
            }
        }
    }
}
