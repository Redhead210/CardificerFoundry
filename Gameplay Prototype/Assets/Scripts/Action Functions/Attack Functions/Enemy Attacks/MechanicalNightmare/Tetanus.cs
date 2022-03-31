/**
// File Name :         Tetanus.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies damage and toxin the the target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetanus : EnemyAttack
{
    public Tetanus()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Tetanus";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Tetanus";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        target.TakeDamage(8);
        target.ApplyEffect("toxin", 8);
        target.Particle(BattleManager.Effects.Slash);
        target.Particle(BattleManager.Effects.Toxin);
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}