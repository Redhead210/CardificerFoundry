/**
// File Name :         UmbraBurst.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : deals damage to the target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbraBurst : EnemyAttack
{
    public UmbraBurst()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "UmbraBurst";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Umbra Burst";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(6);
        target.Particle(BattleManager.Effects.Blast);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
