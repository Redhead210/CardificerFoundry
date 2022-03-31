/**
// File Name :         PipeBurst.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBurst: EnemyAttack
{
    public PipeBurst()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "PipeBurst";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Pipe Burst";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(7, "Pop");
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }

}
