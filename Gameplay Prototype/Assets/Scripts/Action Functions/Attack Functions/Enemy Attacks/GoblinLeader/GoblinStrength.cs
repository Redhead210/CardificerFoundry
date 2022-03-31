/**
// File Name :         GoblinStrength.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Goblin Strength attack for goblin leader
**/
using System.Collections.Generic;
using UnityEngine;

public class GoblinStrength : EnemyAttack
{
    public GoblinStrength()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "GoblinStrength";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Goblin Strength";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        target.TakeDamage(10);
        target.ApplyEffect("frost", 5);
        target.Particle(BattleManager.Effects.Frost);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
