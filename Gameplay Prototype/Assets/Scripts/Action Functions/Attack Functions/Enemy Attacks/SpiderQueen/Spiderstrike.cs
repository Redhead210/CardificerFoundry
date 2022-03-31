/**
// File Name :         Spiderstrike.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : heals the caster, and deals damage and toxin to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderstrike : EnemyAttack
{
public Spiderstrike()
    {
        //Set attack target here
        target = EnemyAttack.GetHighestHPEnemy();
    }

    public override string GetClass()
    {
        return "Spiderstrike";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Spiderstrike";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        caster.Heal(8);
        caster.Particle(BattleManager.Effects.Radience);
        target.TakeDamage(8);
        target.Particle(BattleManager.Effects.Slash);
        target.ApplyEffect("toxin", 8);
        target.Particle(BattleManager.Effects.Toxin);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
