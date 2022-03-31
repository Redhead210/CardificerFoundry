/**
// File Name :         Unstoppable.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies armor and block to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unstoppable : EnemyAttack
{
public Unstoppable()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Unstoppable";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Unstoppable";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("armor", 1);
        caster.block += 6;
        caster.Particle(BattleManager.Effects.Block);
        caster.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
