/**
// File Name :         CoveringFire.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that applies block to allies and damages players
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoveringFire : EnemyAttack
{
    public override string GetClass()
    {
        return "CoveringFire";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Defense };
    }
    public override string GetName()
    {
        return "Covering Fire";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        caster.block += 4;
        caster.Particle(BattleManager.Effects.Block);
        foreach (CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            cb.TakeDamage(1);
            cb.Particle(BattleManager.Effects.Bullet);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
