
/**
// File Name :         RqyOfHope.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : heals all allies and allies radiance
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOfHope : Card
{
    public override string cardClass()
    {
        return "RayOfHope";
    }

    public override string cardName()
    {
        return "Hope";
    }

    public override string FlavorText()
    {
        return "It feels a little more patronizing when you're healthy.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Heal all allies for 4. Then apply 2 Radiance to them.";
        }
        if (rank == 2)
        {
            return "Heal all allies for 3. Then apply 1 Radiance to them";
        }

        return "Heal all allies for 2. Then apply 1 Radiance to them";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 4;
        }
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 2;
        var r = 1;
        if (rank == 2)
        {
            h = 3;
        }
        if (rank == 3)
        {
            r = 2;
            h = 4;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.Heal(h);

            c.ApplyEffect("radiance", r);
            c.Particle(BattleManager.Effects.Light);
        }
    }
}
