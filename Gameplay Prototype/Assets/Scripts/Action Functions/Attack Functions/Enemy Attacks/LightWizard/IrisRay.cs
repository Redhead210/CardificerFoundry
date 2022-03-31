/**
// File Name :         IrisRay.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Deals damage and applies radiance
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisRay: EnemyAttack
{
    public IrisRay()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "IrisRay";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Iris Ray";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(6);
        caster.ApplyEffect("radiance", 2);
        caster.Particle(BattleManager.Effects.Radience);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
