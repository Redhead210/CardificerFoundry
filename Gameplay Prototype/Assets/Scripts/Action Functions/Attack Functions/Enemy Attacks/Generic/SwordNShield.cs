/**
// File Name :         SwordNShield.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage to target and applies block to caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordNShield : EnemyAttack
{
public SwordNShield()
    {
        //Set attack target here
        target = EnemyAttack.GetRandomTarget();
    }

    public override string GetClass()
    {
        return "SwordNShield";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "SwordNShield";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(7);
        caster.block += 7;
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
