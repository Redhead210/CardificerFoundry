/**
// File Name :         TreeOfLife.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Removes negative effects, and applies positive effects
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : Card
{
    public override string cardClass()
    {
        return "TreeOfLife";
    }

    public override string cardName()
    {
        return "Refresh";
    }

    public override string FlavorText()
    {
        return "12 in 1 Status Effect remover.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Remove all of the Party's negative status effects, and applies 4 regen";
        }
        if (rank == 2)
        {
            return "Remove all of the Party's status effects, and applies 2 regen";
        }

        return "Remove all of the Party's status effects";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 5;
        }

        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var r = 2;
        if (rank == 3)
        {
            r = 4;
        }


        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.Particle(BattleManager.Effects.Regen);
            if (rank >= 2)
            {
                c.ApplyEffect("regen", r);
            }
            if (rank < 3)
            {
                c.RemoveAllEffects();
            }
            else
            {
                //Remove All negative effects
                foreach (StatusEffect s in c.statusEffects)
                {
                    switch (s.name)
                    {
                        case "toxin":
                        case "burn":
                        case "frost":
                            c.RemoveEffect(s.name);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
