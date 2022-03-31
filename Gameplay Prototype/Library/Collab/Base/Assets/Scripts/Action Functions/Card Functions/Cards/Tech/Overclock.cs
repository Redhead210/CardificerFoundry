using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overclock : Card
{

    public override string cardClass()
    {
        return "Overclock";
    }

    public override string cardName()
    {
        return "Overclock";
    }

    public override string cardDesc()
    {
        if (rank == 2)
        {
            return "Apply ["+ (BattleManager.innovate)+"] + 1 Power. Innovate";
        }
        return "Apply ["+ (BattleManager.innovate) + "] Power. Innovate";
    }

    public override Targets cardTarget()
    {
        return Targets.Players;
    }

    public override int cardSpeed()
    {
        if (rank == 2)
        {
            return 2;
        }
        return 3;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        var p = 0;
        if (rank == 2)
        {
            p = 1;
        }

        if (p+BattleManager.innovate != 0)
        {
            cb.ApplyEffect("power", BattleManager.innovate + p);
        }

        BattleManager.innovate++;
    }
}
