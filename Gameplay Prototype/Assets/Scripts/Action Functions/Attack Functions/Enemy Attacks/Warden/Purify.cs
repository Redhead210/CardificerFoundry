/**
// File Name :         Purify.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : removes all negative status effects
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purify : EnemyAttack
{
public Purify()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Purify";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Purify";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        var r = caster.EffectStacks("regen");
        var rd = caster.EffectStacks("radiance");

        caster.RemoveAllEffects();
        caster.ApplyEffect("regen", r);
        caster.ApplyEffect("radiance", rd);
        caster.Heal(10);

        caster.Particle(BattleManager.Effects.Regen);
        caster.Particle(BattleManager.Effects.Light);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return caster.statusEffects.Count > 0;
    }
}
