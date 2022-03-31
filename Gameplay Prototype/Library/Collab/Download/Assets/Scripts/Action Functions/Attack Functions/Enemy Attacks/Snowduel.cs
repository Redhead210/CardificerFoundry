using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowduel : EnemyAttack
{
public Snowduel()
    {
        //Set attack target here
        target = GetRandomTarget();
    }

    public override string GetClass()
    {
        return "Snowduel";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff, Type.Defense };
    }
    public override string GetName()
    {
        return "Snowduel";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        var e = target.TakeDamage(6);
        target.ApplyEffect("frost",e);

        target.block += 6;
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
