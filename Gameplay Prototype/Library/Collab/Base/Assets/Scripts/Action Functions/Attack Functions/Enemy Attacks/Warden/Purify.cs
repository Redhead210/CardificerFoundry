using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purify : EnemyAttack
{
public Purify()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Purify";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Purify";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        var h = 0;
        foreach (StatusEffect s in caster.statusEffects)
        {
            switch(s.name)
            {
                case "toxin":
                case "burn":
                case "frost":
                case "mark":
                    h += s.stacks;
                    caster.RemoveEffect(s.name);
                    break;
            }
        }

        caster.Heal(h);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return caster.statusEffects.Count > 0;
    }
}
