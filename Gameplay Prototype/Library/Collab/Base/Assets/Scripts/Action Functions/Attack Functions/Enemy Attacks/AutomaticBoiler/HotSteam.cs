/**
// File Name :         HotSteam.cs
// Author :            JasonCzech
// Creation Date :     October, 2021
//
// Brief Description : Handles tutorial in map
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSteam : EnemyAttack
{
    public HotSteam()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "HotSteam";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Hot Steam";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(12,"Hiss");
        target.ApplyEffect("burn", 8);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
