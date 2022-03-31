/**
// File Name :         Swarm.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : applies haste to allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : EnemyAttack
{
    public Swarm()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Swarm";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Swarm";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
     

        target.TakeDamage(3);
        target.Particle(BattleManager.Effects.Slash);

        foreach (CharacterBehaviour e in CharacterBehaviour.getAllEnemies())
        {
            e.ApplyEffect("haste", 2);
            e.Particle(BattleManager.Effects.Smoke);
        }
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}