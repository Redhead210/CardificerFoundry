/**
// File Name :         RattlinBog.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Rattlin Bog attack for skeleton
**/
using System.Collections.Generic;
using UnityEngine;

public class RattlinBog : EnemyAttack
{
    public RattlinBog()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "RattlinBog";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Rattlin' Bog";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.TakeDamage(3);
            c.Particle(BattleManager.Effects.Slash);
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("haste", 1);
            c.Particle(BattleManager.Effects.Smoke);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
