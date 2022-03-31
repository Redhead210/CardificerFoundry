/**
// File Name :         Taunt.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies taunt to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : EnemyAttack
{

    public override string GetClass()
    {
        return "Taunt";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Taunt";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("taunt", 1);
        caster.Particle(BattleManager.Effects.Taunt);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
