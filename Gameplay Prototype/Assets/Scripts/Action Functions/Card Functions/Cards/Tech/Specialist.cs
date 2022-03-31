/**
// File Name :         Specialist.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies an effect on the caster based on their secondary typing and the innovate level
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialist : Card
{
    public override string cardClass()
    {
        return "Specialist";
    }

    public override string cardName()
    {
        return "Specialist";
    }

    public override string FlavorText()
    {
        return "Problems come in all shapes and sizes. So do wrenches.";
    }

    public override string cardDesc()
    {
        var s = "";
        if (rank > 1)
        {
            s = " * " + rank;
        }

        var bm = GameObject.FindObjectOfType<BattleManager>();
        if (bm == null || BattleManager.selectedCharacter == null)
        {
            return "Apply [" + BattleManager.innovate + "]+1" + s + " of a status effect based on this character's secondary type. Innovate.";
        }
        else
        {
            switch (BattleManager.selectedCharacter.thisChar.types[0])
            {
                case CardTypes.Fire:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Burn to an enemy.";
                case CardTypes.Ice:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Frost to an enemy.";
                case CardTypes.Light:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Radiance to an ally.";
                case CardTypes.Melee:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " turns of Taunt and block to an ally.";
                case CardTypes.Nature:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Regen to an ally.";
                case CardTypes.Ranged:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Mark to an enemy.";
                case CardTypes.Shadow:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Haste to an ally.";
            }

            switch (BattleManager.selectedCharacter.thisChar.types[1])
            {
                case CardTypes.Fire:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Burn to an enemy.";
                case CardTypes.Ice:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Frost to an enemy.";
                case CardTypes.Light:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Radiance to an ally.";
                case CardTypes.Melee:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " turns of Taunt and block to an ally.";
                case CardTypes.Nature:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Regen to an ally.";
                case CardTypes.Ranged:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Mark to an enemy.";
                case CardTypes.Shadow:
                    return "Apply [" + BattleManager.innovate + "]+1" + s + " Haste to an ally.";
            }
        }

        return "If you're seeing this something is bugged.";
    }

    public override Targets cardTarget()
    {
        if (cardDesc().Contains("ally"))
        {
            return Targets.Players;
        }

        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 2;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var t = BattleManager.currentlyActing.thisChar.types[0];
        if (t == CardTypes.Tech)
        {
            t = BattleManager.currentlyActing.thisChar.types[1];
        }

        var e = "";
        BattleManager.Effects ef = BattleManager.Effects.Cogs;

        switch (t)
        {
            case CardTypes.Ice:
                e = "frost";
                ef = BattleManager.Effects.Frost;
                break;
            case CardTypes.Fire:
                e = "burn";
                ef = BattleManager.Effects.Fire;
                break;
            case CardTypes.Light:
                e = "radiance";
                ef = BattleManager.Effects.Radience;
                break;
            case CardTypes.Melee:
                e = "taunt";
                ef = BattleManager.Effects.Taunt;
                cb.block += (BattleManager.innovate + 1) * rank;
                break;
            case CardTypes.Nature:
                e = "regen";
                ef = BattleManager.Effects.Regen;
                break;
            case CardTypes.Ranged:
                e = "mark";
                ef = BattleManager.Effects.Mark;
                break;
            case CardTypes.Shadow:
                e = "haste";
                ef = BattleManager.Effects.Smoke;
                break;
        }

        var a = (BattleManager.innovate + 1) * rank;
        cb.ApplyEffect(e, a);
        cb.Particle(BattleManager.Effects.Cogs);
        cb.Particle(ef);

        BattleManager.innovate++;
        caster.ShowMessage("Innovate [" + BattleManager.innovate + "]", cardColor());
    }
}
