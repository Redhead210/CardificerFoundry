using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomStrike : Card
{
    public override string cardClass()
    {
        return "VenomStrike";
    }

    public override string cardName()
    {
        return "Venom Strike";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 7 damage to an enemy and apply 7 Poison. Gain 7 Regen.";
        }
        if (rank == 2)
        {
            return "Deal 4 damage to an enemy and apply 4 Poison. Gain 4 Regen.";
        }
        return "Deal 3 damage to an enemy and apply 3 Poison. Gain 3 Regen.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 4;
        }
        if (rank == 2)
        {
            return 5;
        }
        return 6;
    }

    public override string FlavorText()
    {
        return "Wait, human's have venom?";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Nature;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var a = 3;
        if (rank == 2)
        {
            a = 4;
        }
        if (rank == 3)
        {
            a = 7;
        }

        cb.TakeDamage(a);
        cb.ApplyEffect("toxin",a);
        caster.ApplyEffect("regen", a);

    }
}
