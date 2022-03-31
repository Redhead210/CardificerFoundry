/**
// File Name :         Photosynthesis.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies radiance and regen to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photosynthesis : EnemyAttack
{
public Photosynthesis()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Photosynthesis";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Photosynthesis";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("radiance",1);
        caster.ApplyEffect("regen", 2);

        caster.Particle(BattleManager.Effects.Regen);
        caster.Particle(BattleManager.Effects.Radience);
        caster.Particle(BattleManager.Effects.Light);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
