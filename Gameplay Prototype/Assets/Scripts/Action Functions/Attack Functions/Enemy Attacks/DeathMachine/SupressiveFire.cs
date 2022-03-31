/**
// File Name :         SupressiveFire.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : deals damage to all player allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupressiveFire : EnemyAttack
{
    public SupressiveFire()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "SupressiveFire";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Supressive Fire";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.TakeDamage(4);
            c.Particle(BattleManager.Effects.Bullet);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}