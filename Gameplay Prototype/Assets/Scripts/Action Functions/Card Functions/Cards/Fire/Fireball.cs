/**
// File Name :         Fireball.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Firebolt attack
**/
using UnityEngine;

public class Fireball : Card
{
    public override string cardClass()
    {
        return "Fireball";
    }
    public override string cardName()
    {
        return "Firebolt";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Deal 5 damage. Apply 4 Burn.";
        }
        else if(rank==3)
        {
            return "Deal 8 damage. Apply 6 Burn.";
        }

        return "Deal 4 damage. Apply 3 Burn.";
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 3;
        }
        else if(rank==3)
        {
            return 6;
        }
        return 4;
    }

    public override Targets cardTarget()
    {
        return Targets.Enemy;
    }

    public override string FlavorText()
    {
        return "A tad more original than \"Fireball.\"";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Fire;
    }

    public override Color cardColor()
    {
        return new Color(0.6f, 0, 0);
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var d = 4;
        var b = 3;

        if (rank == 2)
        {
            d = 5;
            b = 4;
        }
        else if(rank==3)
        {
            d = 8;
            b = 6;
        }

        cb.TakeDamage(d);
        cb.ApplyEffect("burn", b);
        cb.Particle(BattleManager.Effects.Fire);
    }
}
