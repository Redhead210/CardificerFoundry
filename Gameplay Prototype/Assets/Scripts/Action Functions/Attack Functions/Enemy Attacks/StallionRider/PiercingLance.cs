/**
// File Name :         PiercingLance.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Piercing Lance attack for Stallion
**/
using System.Collections.Generic;
using UnityEngine;

public class PiercingLance : EnemyAttack
{
    public PiercingLance()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "PiercingLance";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Piercing Lance";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(5);
        target.Particle(BattleManager.Effects.Slash);
        target.ApplyEffect("frost", 2);
        target.Particle(BattleManager.Effects.Frost);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
