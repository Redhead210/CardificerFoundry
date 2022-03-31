
/**
// File Name :         Scorch.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Applies burn and deals damage equal to that burn
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorch : Card
{
    public override string cardClass()
    {
        return "Scorch";
    }

    public override string cardName()
    {
        return "Scorch";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Apply 5 Burn. The target takes damage equal to their Burn.";
        }
        else if (rank==3)
        {
            return "Apply 8 Burn. The target takes damage equal to their Burn.";
        }

        return "Apply 3 Burn. The target takes damage equal to their Burn.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override string FlavorText()
    {
        return "General Sherman has nothing on the Cardificer.";
    }

    public override int cardSpeed()
    {
        return 5;
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
        else if (rank == 3)
        {
            b = 8;
        }

        cb.ApplyEffect("burn", b);
        cb.TakeDamage(cb.EffectStacks("burn"));

        cb.Particle(BattleManager.Effects.Fire);
        cb.Particle(BattleManager.Effects.Punch);
    }
}
