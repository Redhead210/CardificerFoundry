/**
// File Name :         Incubate.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Heals an enemy based on the amount of poison is has
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incubate : EnemyAttack
{
public Incubate()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Incubate";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense, Type.Buff };
    }
    public override string GetName()
    {
        return "Incubate";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        var b = 0;
        foreach(CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            b += cb.EffectStacks("toxin");
            cb.Particle(BattleManager.Effects.Toxin);
        }

        caster.block += b;
        caster.Particle(BattleManager.Effects.Block);
        caster.Heal(8);
        caster.Particle(BattleManager.Effects.Radience);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
