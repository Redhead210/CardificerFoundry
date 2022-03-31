/**
// File Name :         Overheat.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : applies burn and damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeat : EnemyAttack
{
    public OverHeat()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "OverHeat";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Overheat";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("burn", 5);
        target.TakeDamage(10, "Woosh");
        caster.ApplyEffect("burn", 5);
        caster.Particle(BattleManager.Effects.Fire);
        target.Particle(BattleManager.Effects.Blast);
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}

