/**
// File Name :         BarrelHeat.cs
// Author :            Will Bennington
// Creation Date :     October 2021
//
// Brief Description : A fire attack for death machine
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHeat : EnemyAttack
{
    public BarrelHeat()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "BarrelHeat";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Barrel Heat";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        target.TakeDamage(4, "Brrrrrrrrrrrrrrrr");
        target.Particle(BattleManager.Effects.Bullet);
        target.ApplyEffect("burn", 3);
        target.Particle(BattleManager.Effects.Fire);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
