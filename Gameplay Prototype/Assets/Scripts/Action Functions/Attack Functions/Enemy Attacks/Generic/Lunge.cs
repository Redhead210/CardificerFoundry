/**
// File Name :         Lunge.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals low damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : EnemyAttack
{
    public Lunge()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Lunge";
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
        target.TakeDamage(4);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }

}
