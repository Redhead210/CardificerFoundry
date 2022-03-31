/**
// File Name :         AlphaLunge.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Lunge attack alpha goblin
**/
using System.Collections.Generic;
using UnityEngine;

public class AlphaLunge : EnemyAttack
{
    public AlphaLunge()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "AlphaLunge";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Lunge";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        target.TakeDamage(10);
        target.Particle(BattleManager.Effects.Cogs);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
