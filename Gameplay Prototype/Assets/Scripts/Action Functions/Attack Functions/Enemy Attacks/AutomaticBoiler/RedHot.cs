
/**
// File Name :         RedHot.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : applies haste and power to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHot : EnemyAttack
{
    public RedHot()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "RedHot";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Red Hot";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("haste", 1);
        caster.ApplyEffect("power", 1);
        caster.Particle(BattleManager.Effects.Power);
        caster.Particle(BattleManager.Effects.Smoke);
    }

    public override bool CanBeUsed()
    {
        return true;
    }

}
