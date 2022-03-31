using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulverize : EnemyAttack
{
public Pulverize()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Pulverize";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Pulverize";
    }
    public override int GetSpeed()
    {
        return 10;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("power", 1);
        var attacked = false;
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            if (!c.HasActed())
            {
                c.TakeDamage(3, "1'V3 G0T Y0U...");
                if (caster.EffectStacks("haste") > 0)
                {
                    caster.SubtractEffect("haste", 2);
                }
                attacked = true;
            }
        }

        if (!attacked)
        {
            caster.ShowMessage("F1NDING T4RG3T...", Color.magenta);
            caster.ApplyEffect("haste", 1);
        }

    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
