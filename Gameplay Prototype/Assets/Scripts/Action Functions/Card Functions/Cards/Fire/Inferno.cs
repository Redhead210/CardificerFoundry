/**
// File Name :         Inferno.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies burn flat out
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inferno : Card
{
    public override string cardClass()
    {
        return "Inferno";
    }

    public override string cardName()
    {
        return "Inferno";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Apply 6 Burn.";
        }
        else if(rank==3)
        {
            return "Apply 10 Burn.";
        }

        return "Apply 4 Burn.";
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override Color cardColor()
    {
        return new Color(0.6f, 0, 0);
    }

    public override int cardSpeed()
    {
        return 5;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override string FlavorText()
    {
        return "The real forest fire was the friendships we made along the way!";
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var f = 4;

        if (rank == 2)
        {
            f = 6;
        }
        else if (rank==3)
        {
            f = 10;
        }
        cb.ApplyEffect("burn", f);

        cb.Particle(BattleManager.Effects.Fire);
    }
}
