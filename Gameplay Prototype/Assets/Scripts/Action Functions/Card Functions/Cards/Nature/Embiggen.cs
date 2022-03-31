/**
// File Name :         Enbiggen.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : heals players, and deals damage depending on the max health
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embiggen : Card
{
    public override string cardClass()
    {
        return "Embiggen";
    }
    public override string cardName()
    {
        return "Embiggen";
    }

    public override string FlavorText()
    {
        return "The only thing that gets bigger is your self confidence and thirst for destruction!";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Restore 8 Health and deal 6 damage. If this has the most HP, deal 16 instead.";
        }
        if (rank == 2)
        {
            return "Restore 4 Health and deal 5 damage. If this has the most HP, deal 10 instead.";
        }
        return "Restore 2 Health and deal 4 damage. If this has the most HP, deal 8 instead.";
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 5;
        }
        return 6;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override Color cardColor()
    {
        return new Color(0f, 0.4f, 0f);
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 2;
        var d = 4;
        var ed = 8;

        if (rank == 2)
        {
            h = 4;
            d = 5;
            ed = 10;
        }
        if (rank == 3)
        {
            h = 8;
            d = 6;
            ed = 16;
        }


        caster.Heal(h);

        if (CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllAlive()) == caster)
        {
            cb.TakeDamage(ed,"Stomp!");
        }
        else
        {
            cb.TakeDamage(d);
        }

        caster.Particle(BattleManager.Effects.Regen);
        cb.Particle(BattleManager.Effects.Punch);
    }
}
