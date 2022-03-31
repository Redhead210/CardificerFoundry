/**
// File Name :         Flex.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Applies Power to the cardificer and the caster as well as damageing the target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flex : EnemyAttack
{
    public Flex()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Flex";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Pollish off";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {

        var Cardificer= CharacterBehaviour.GetCharAtIndex(true, 2);
        caster.ApplyEffect("power", 2);
        Cardificer.ApplyEffect("power", 2);
        target.TakeDamage(6);
        target.Particle(BattleManager.Effects.Smoke);
        caster.Particle(BattleManager.Effects.Power);
        Cardificer.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
        return true;

    }
}