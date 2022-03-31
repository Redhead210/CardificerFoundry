/**
// File Name :         WitnessesWatch.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies damage, frost, and mark to all enemies, as well as block to all allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessesWatch : Card
{
    public override string cardClass()
    {
        return "WitnessesWatch";
    }

    public override string cardName()
    {
        return "Watchover";
    }

    public override string FlavorText()
    {
        return "They had failed their mission, and they were exiled for it. Now they seek only to stop what they should have prevented.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 6 Damage, apply 6 Frost and 2 Mark to all enemies. Apply 6 Block to all allies.";
        }
        if (rank == 2)
        {
            return "Deal 3 Damage, apply 3 Frost and 1 Mark to all enemies. Apply 3 Block to all allies.";
        }
        return "Deal 2 Damage, apply 2 Frost and 1 Mark to all enemies. Apply 2 Block to all allies.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override Color cardColor()
    {
        return new Color32(79, 146, 146, 255);
    }

    public override int cardSpeed()
    {
        return 6-rank;
    }

    public override string Bound()
    {
        return "The Witness";
    }

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 2;
        var m = 1;
        if (rank == 2)
        {
            d = 3;
            
        }
        if (rank == 3)
        {
            d = 5;
            m = 2;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.TakeDamage(d);
            c.ApplyEffect("frost", d);
            c.ApplyEffect("mark", m);
            c.Particle(BattleManager.Effects.Frost);
            c.Particle(BattleManager.Effects.Bullet);
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.block += d;
            c.Particle(BattleManager.Effects.Block);
        }
    }
}
