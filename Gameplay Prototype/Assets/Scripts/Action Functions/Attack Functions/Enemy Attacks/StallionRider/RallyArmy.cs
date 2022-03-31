/**
// File Name :         RallyArmy.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Rally Army attack for Stallion
**/
using System.Collections.Generic;
using UnityEngine;

public class RallyArmy : EnemyAttack
{
    public RallyArmy()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "RallyArmy";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Rally Army";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("haste", 1);
            c.Particle(BattleManager.Effects.Smoke);
            c.block += 2;
            c.Particle(BattleManager.Effects.Block);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
