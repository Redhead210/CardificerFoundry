/**
// File Name :         Slap.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Adds innovate and damages players
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : EnemyAttack
{
    public Slap()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Slap";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Slap";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        BattleManager.innovate += 2;
        target.TakeDamage(10, "Whack");
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
