using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMomentum : Card
{
    public override string cardClass()
    {
        return "BuildMomentum";
    }

    public override string cardName()
    {
        return "Evasion";
    }

    public override string FlavorText()
    {
        return "Dodge this.";
    }

    public override bool SynergyCard()
    {
        return false;
    }

    public override string cardDesc()
    {
        if (rank == 3)
        {
            return "Nullify enemy actions. Gain 4 Haste.";
        }
        if (rank == 2)
        {
            return "Nullify enemy actions targeting this Character. Gain 3 Haste.";
        }
        return "Nullify enemy actions targeting this Character. Gain 2 Haste.";
    }

    public override Targets cardTarget()
    {
        return Targets.None;
    }

    public override int cardSpeed()
    {
        if (rank != 1)
        {
            return 5;
        }
        return 6;
    }

    public override CardTypes cardType()
    {
        return CardTypes.Shadow;
    }

    public override void castCard(CharacterBehaviour cb = null)
    {
        /*
        foreach (AttackData a in BattleManager.queue)
        {
            if (a.allignment == AttackData.Side.Enemy && a.target == caster)
            {
                BattleManager.queue.Remove(a);
            }
        }
        */

        for (int i = 0; i < BattleManager.queue.Count; i++)
        {
            var a = BattleManager.queue[i];
            if (a.allignment == AttackData.Side.Enemy && (a.target == caster || rank == 3))
            {
                BattleManager.queue.RemoveAt(i);
                i--;
                a.caster.Particle(BattleManager.Effects.Smoke);
                a.caster.ShowMessage("Skipped Attack", cardColor());
            }
        }

        caster.ApplyEffect("haste", 1 + rank);
    }
}
