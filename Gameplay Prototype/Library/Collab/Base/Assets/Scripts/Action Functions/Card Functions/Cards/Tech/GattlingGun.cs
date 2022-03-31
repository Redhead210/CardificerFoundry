using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GattlingGun : Card
{
    public override string cardClass()
    {
        return "GattlingGun";
    }

    public override string cardName()
    {
        return "Gattling Gun";
    }

    public override string FlavorText()
    {
        return "Beautiful things have been created from combining a firearm and a jack-in-the-box.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Deal 3 damage to the enemy with the highest health ["+(BattleManager.innovate)+"] + 5 times. Innovate";
        }

        return "Deal 2 damage to the enemy with the highest health [" + (BattleManager.innovate) + "] + 4 times. Innovate";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }
   

    public override void castCard(CharacterBehaviour cb = null)
    {
        var t = 4;
        var d = 2;
        if (rank == 2)
        {
            t = 4;
            d = 2;
        }
        if (rank == 3)
        {
            t = 5;
            d = 3;
        }

        for(int i = 0; i < t+BattleManager.innovate; i++)
        {
            var trg = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllEnemies());
            trg.TakeDamage(d);
            trg.Particle(BattleManager.Effects.Bullet);
        }

        caster.Particle(BattleManager.Effects.Cogs);

        BattleManager.innovate++;
    }
}
