using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Card
{
    public override string cardClass()
    {
        return "Flamethrower";
    }

    public override string cardName()
    {
        return "Flamethrower";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 1 Damage to the enemy with the highest health 12 times. Enemies gain Burn equal to damage dealt.";
        }
        if (rank == 2)
        {
            return "Deal 1 Damage to the enemy with the highest health 10 times. Enemies gain Burn equal to damage dealt.";
        }
        return "Deal 1 Damage to the enemy with the highest health 8 times. Enemies gain Burn equal to damage dealt.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 6;
        }
        return 8;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }
    public override string FlavorText()
    {
        return "You don't have to know fire magic. You just have to have tenacity, a love of arson, and a disregard for the Geneva Convention.";
    }


    public override void castCard(CharacterBehaviour cb = null)
    {
        var r = 8;
        if (rank == 2)
        {
            r = 10;
        }
        if (rank == 3)
        {
            r = 12;
        }

        for (int i = 0; i < r; i++)
        {
            var t = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllEnemies());
            t.ApplyEffect("burn", t.TakeDamage(1));
        }
    }
}
