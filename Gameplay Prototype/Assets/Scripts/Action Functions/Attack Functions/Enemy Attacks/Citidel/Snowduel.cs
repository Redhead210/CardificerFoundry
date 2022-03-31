/**
// File Name :         Snowduel.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies damage and frost to the target, and heal the caster
**/
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
        target.Particle(BattleManager.Effects.Frost);

        target.block += 6;
        target.Particle(BattleManager.Effects.Block);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
