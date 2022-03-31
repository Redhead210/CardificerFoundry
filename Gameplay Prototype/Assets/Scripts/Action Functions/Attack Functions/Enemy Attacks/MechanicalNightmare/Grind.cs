/**
// File Name :         Grind.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Handles tutorial in map
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grind : EnemyAttack
{
    public Grind()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Grind";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Grind";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {

        target.Particle(BattleManager.Effects.Cogs);
        target.TakeDamage(10);
      
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}
