/**
// File Name :         Harass.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : enemy attack that deals low damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harass : EnemyAttack
{
    public Harass()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Harass";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Harass";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        target.TakeDamage(2);
        target.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
