/**
// File Name :         NaturalDefense.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies armor to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalDefense : EnemyAttack
{
public NaturalDefense()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "NaturalDefense";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Natural Defense";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
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
