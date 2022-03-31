/**
// File Name :         Overwatch.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies mark
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overwatch : EnemyAttack
{
public Overwatch()
    {
        //Set attack target here
        target = GetRandomTarget();
    }

    public override string GetClass()
    {
        return "Overwatch";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff };
    }
    public override string GetName()
    {
        return "Overwatch";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        target.ApplyEffect("mark",1);
        target.Particle(BattleManager.Effects.Mark);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
