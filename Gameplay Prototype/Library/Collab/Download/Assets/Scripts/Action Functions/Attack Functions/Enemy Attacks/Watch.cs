using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : EnemyAttack
{
public Watch()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Watch";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff };
    }
    public override string GetName()
    {
        return "Watch";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour cb in CharacterBehaviour.getAllEnemies())
        {
            cb.ApplyEffect("mark",1);
        }

        caster.ApplyEffect("power", 2);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
