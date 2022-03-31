/**
// File Name :         ShadowSwift.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Applies haste to all enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSwift : EnemyAttack
{
    public ShadowSwift()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "ShadowSwift ";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Shadow Swift";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
       foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("haste",2);
            c.Particle(BattleManager.Effects.Smoke);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
