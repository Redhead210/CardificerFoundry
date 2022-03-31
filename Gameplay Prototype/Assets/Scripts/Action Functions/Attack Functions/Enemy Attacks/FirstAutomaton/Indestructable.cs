/**
// File Name :         Industructable.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies block up to the amount of power the enemy has
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indestructable : EnemyAttack
{
public Indestructable()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Indestructable";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense };
    }
    public override string GetName()
    {
        return "Indestructable";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        caster.block += 1 + caster.EffectStacks("power");
        caster.Particle(BattleManager.Effects.Smoke);
        caster.Particle(BattleManager.Effects.Block);
        caster.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
        return CharacterBehaviour.getAllEnemies()[0].EffectStacks("power") > 5;
    }
}
