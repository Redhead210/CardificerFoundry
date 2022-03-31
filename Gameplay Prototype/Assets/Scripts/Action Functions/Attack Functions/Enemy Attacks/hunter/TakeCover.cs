/**
// File Name :         TakeCover.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies block to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCover : EnemyAttack
{
public TakeCover()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "TakeCover";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense };
    }
    public override string GetName()
    {
        return "Take Cover";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        caster.block += 15;

        caster.Particle(BattleManager.Effects.Blast);
        caster.Particle(BattleManager.Effects.Block);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
