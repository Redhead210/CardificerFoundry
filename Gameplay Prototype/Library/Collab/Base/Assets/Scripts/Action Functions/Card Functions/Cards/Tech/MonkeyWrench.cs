using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyWrench : Card
{
    public override string cardClass()
    {
        return "MonkeyWrench";
    }

    public override string cardName()
    {
        return "Monkey Wrench";
    }

    public override string FlavorText()
    {
        return "The greatest tool for innovation is duct tape. This comes second.";
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Innovate 6. Apply 4 Block to all allies.";
        }
        if (rank == 2)
        {
            return "Innovate 4.";
        }
        return "Innovate 2.";
    }

    public override bool SynergyCard()
    {
        return true;
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        return 2;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Tech;
    }

    

    public override void castCard(CharacterBehaviour cb = null)
    {
        var i = 2;
        if (rank >= 2)
        {
            i = 4;
        }

        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.Particle(BattleManager.Effects.Cogs);
        }

        BattleManager.innovate += i;

        if (rank == 3)
        {
            BattleManager.innovate += 2;
            foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
            {
                c.block += 4;
            }
        }
    }
}
