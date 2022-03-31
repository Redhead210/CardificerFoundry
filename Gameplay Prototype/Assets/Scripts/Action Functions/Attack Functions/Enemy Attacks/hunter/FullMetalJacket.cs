/**
// File Name :         FullMetalJacket.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Applies power and block to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMetalJacket : EnemyAttack
{
public FullMetalJacket()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "FullMetalJacket";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense, Type.Buff };
    }
    public override string GetName()
    {
        return "Full Metal Jacket";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("power", 1);
        caster.block += 6;

        caster.Particle(BattleManager.Effects.Block);
        caster.Particle(BattleManager.Effects.Bullet);
        caster.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
