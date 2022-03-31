/**
// File Name :         Glacier.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Applies frost to enemies, and then adds block on allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glacier : Card
{
    public override string cardClass()
    {
        return "Glacier";
    }

    public override string cardName()
    {
        return "Glacier";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Apply 4 Frost to all enemies. Apply Block equal to all enemies' Frost to all allies.";
        }
        if (rank == 2)
        {
            return "Apply 3 Frost to all enemies. Apply Block equal to all enemies' Frost.";
        }
        return "Apply 2 Frost to all enemies. Gain Block equal to all enemies' Frost.";
    }

    public override Targets cardTarget()
    {
        if (rank == 2)
        {
            return Targets.Players;
        }
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 4;
        }
        return 5;
    }

    public override string FlavorText()
    {
        return "\"What if we just put a giant moving block of ice riiiiight here?\"";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Ice;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 2;
        if (rank == 2)
        {
            f = 3;
        }
        if (rank == 3)
        {
            f = 4;
        }

        var b = 0;
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("frost", f);
            b += c.EffectStacks("frost");
            c.Particle(BattleManager.Effects.Frost);
        }

        switch (rank)
        {
            case 1:
                caster.block += b;
                caster.Particle(BattleManager.Effects.Block);
                break;
            case 2:
                cb.block += b;
                caster.Particle(BattleManager.Effects.Block);
                break;
            default:
                foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
                {
                    c.block += b;
                    c.Particle(BattleManager.Effects.Block);
                }
                break;
        }
    }
}
