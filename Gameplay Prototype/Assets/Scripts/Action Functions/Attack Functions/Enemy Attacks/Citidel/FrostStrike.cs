/**
// File Name :         FrostStrike.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : Applies frost, mark, and damage to players
**/
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
            target.Particle(BattleManager.Effects.Frost);
        }

        target.ApplyEffect("mark", 1);
        target.Particle(BattleManager.Effects.Mark);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
