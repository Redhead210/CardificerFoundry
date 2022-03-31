using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostStrike : EnemyAttack
{
public FrostStrike()
    {
	//Set attack target here
        target = GetHighestHPEnemy();
    }

    public override string GetClass()
    {
        return "FrostStrike";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Frost Strike";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        var e = target.TakeDamage(10);
        if (e > 0)
        {
            target.ApplyEffect("frost",e);
        }

        target.ApplyEffect("mark", 1);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
