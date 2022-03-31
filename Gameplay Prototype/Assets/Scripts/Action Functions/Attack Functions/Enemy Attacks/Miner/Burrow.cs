/**
// File Name :         Burrow.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that gains power and block each turn
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burrow : EnemyAttack
{
public Burrow()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Burrow";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Burrow";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("power", 2);
        caster.ApplyEffect("armor", 2);
        caster.Particle(BattleManager.Effects.Block);
        caster.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
