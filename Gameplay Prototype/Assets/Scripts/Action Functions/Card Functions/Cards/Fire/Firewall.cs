/**
// File Name :         Firewall.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Firewall attack
**/
using UnityEngine;

public class Firewall : Card
{
    public override string cardClass()
    {
        return "Firewall";
    }

    public override string cardName()
    {
        return "Firewall";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Apply 5 Burn to an enemy and gain Block equal to their Burn.";
        }
        else if (rank==3)
        {
            return "Apply 10 Burn to an enemy and gain Block equal to their Burn.";
        }

        return "Apply 3 Burn to an enemy and gain Block equal to their Burn.";
    }

    public override string FlavorText()
    {
        return "The Cardificer should have just used an antivirus.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override int cardSpeed()
    {
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var b = 3;

        if (rank == 2)
        {
            b = 5;
        }
        if (rank==3)
        {
            b = 10;
        }

        cb.ApplyEffect("burn", b);
        caster.block += cb.EffectStacks("burn");

        caster.Particle(BattleManager.Effects.Blast);
        caster.Particle(BattleManager.Effects.Taunt);

        cb.Particle(BattleManager.Effects.Fire);
    }
}
