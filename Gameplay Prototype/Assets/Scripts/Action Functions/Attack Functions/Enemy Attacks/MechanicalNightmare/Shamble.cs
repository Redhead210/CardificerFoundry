/**
// File Name :         Shamble.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies haste to the caster equal to their block +3
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shamble : EnemyAttack
{
    public Shamble()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Shamble";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Shamble";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("haste",2);
        caster.block += caster.EffectStacks("haste");
        caster.Particle(BattleManager.Effects.Smoke);
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}
