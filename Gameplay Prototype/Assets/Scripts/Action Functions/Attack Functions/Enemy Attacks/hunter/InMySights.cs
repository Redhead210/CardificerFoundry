/**
// File Name :         InMySights.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies mark and removes block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMySights : EnemyAttack
{
public InMySights()
    {
        //Set attack target here
        target = GetHighestHPEnemy();
    }

    public override string GetClass()
    {
        return "InMySights";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff };
    }
    public override string GetName()
    {
        return "In My Sights";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        target.ApplyEffect("mark", 4);
        target.block = 0;

        target.Particle(BattleManager.Effects.Blast);
        target.Particle(BattleManager.Effects.Mark);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
