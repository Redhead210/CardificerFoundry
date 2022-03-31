/**
// File Name :         DrillPunch.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Deals damage to players based on turn basis
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillPunch : EnemyAttack
{
public DrillPunch()
    {
	//Set attack target here
        target = GetHighestHPEnemy();
    }

    public override string GetClass()
    {
        return "Drill-Punch";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "DrillPunch";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        for (int i = 0; i < 3+BattleManager.turns; i++)
        {
            target.TakeDamage(2);
            target.Particle(BattleManager.Effects.Punch);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
