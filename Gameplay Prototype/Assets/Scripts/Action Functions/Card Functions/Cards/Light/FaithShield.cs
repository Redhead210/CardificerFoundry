/**
// File Name :         FaithShield.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Faith Shield attack
**/
using UnityEngine;

public class FaithShield : Card
{
    public override string cardClass()
    {
        return "FaithShield";
    }

    public override string cardName()
    {
        return "Faith's Shield";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Heal 10 to an ally. Excess health is converted to Block.";
        }
        if (rank == 2)
        {
            return "Heal 7 to an an ally. Excess health is converted to Block.";
        }

        return "Heal 5 to an ally. Excess health is converted to Block.";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        if (rank == 3)
        {
            return 3;
        }
        return 4;
    }

    public override string FlavorText()
    {
        return "If you believe it will hurt less, it will. Trust me.";
    }

    public override CardTypes cardType()
    {
        return CardTypes.Light;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var h = 5;
        if (rank == 2)
        {
            h = 7;
        }
        if (rank == 3)
        {
            h = 10;
        }

        var b = Mathf.Max(0, h - cb.Heal(h));
        cb.block += b;

        if (b > 0)
        {
            cb.Particle(BattleManager.Effects.Block);
        }
        cb.Particle(BattleManager.Effects.Light);
        
    }
}
