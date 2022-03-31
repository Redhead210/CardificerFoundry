/**
// File Name :         GridTutorial.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Card that can only be used by the Guardian
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiansGift : Card
{
    public override string cardClass()
    {
        return "GuardiansGift";
    }

    public override string cardName()
    {
        return "Germinate";
    }



    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Gain Taunt for 3 turns and 5 Regen. At the start of each turn, gain 4 Block.";
        }
        if (rank == 2)
        {
            return "Gain Taunt for 2 turns and 3 Regen. At the start of each turn, gain 2 Block.";
        }
        return "Gain Taunt and 2 Regen. At the start of each turn, gain 1 Block.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    
    public override string Bound()
    {
        return "The Guardian";
    }

    public override Color cardColor()
    {
        return new Color32(162, 186, 63, 255);
    }

    public override int cardSpeed()
    {
        return 4 - rank;
    }

    public override CardTypes cardType()
    {
        return CardTypes.None;
    }

    public override string FlavorText()
    {
        return "Years of training under The Warden has made her the ultimate protector, even if she has to run away to prove it.";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 1 + rank;
        var b = rank;
        if (rank == 3)
        {
            b = 4;
        }

        caster.ApplyEffect("taunt", rank);
        caster.ApplyEffect("regen", a);
        caster.ApplyEffect("armor", b);

        BattleManager.spawnEffect(BattleManager.Effects.Taunt, caster);
        BattleManager.spawnEffect(BattleManager.Effects.Regen, caster);
    }
}
