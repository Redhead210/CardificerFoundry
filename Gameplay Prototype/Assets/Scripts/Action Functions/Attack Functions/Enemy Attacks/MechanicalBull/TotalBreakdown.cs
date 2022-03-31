/**
// File Name :         TotalBreakdown.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies damage based on power to both the enemy and the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalBreakdown : EnemyAttack
{
public TotalBreakdown()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "TotalBreakdown";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Total-Breakdown";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        var d = caster.EffectStacks("power");
        caster.TakeDamage(d * 2);
        caster.Particle(BattleManager.Effects.Blast);
        caster.Particle(BattleManager.Effects.Fire);

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.TakeDamage(d);
            c.Particle(BattleManager.Effects.Blast);
        }

        caster.RemoveEffect("power");
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return CharacterBehaviour.getAllEnemies()[0].EffectStacks("power") >= 20;
    }
}
