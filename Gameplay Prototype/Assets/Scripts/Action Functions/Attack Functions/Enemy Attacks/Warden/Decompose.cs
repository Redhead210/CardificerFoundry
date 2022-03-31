/**
// File Name :         Decompose.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy Attack that heals enemies the same amount that the players are damaged
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decompose : EnemyAttack
{
public Decompose()
    {
        //Set attack target here
        target = GetHighestHPEnemy();
    }

    public override string GetClass()
    {
        return "Decompose";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Decompose";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        caster.Heal(target.TakeDamage(6, "(you are mine.)"));
        caster.Particle(BattleManager.Effects.Regen);
        target.Particle(BattleManager.Effects.Smoke);
        target.Particle(BattleManager.Effects.Toxin);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
