/**
// File Name :         SweepingEdge.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies damage and frost to player allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepingEdge : EnemyAttack
{
public SweepingEdge()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "SweepingEdge";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Freezing Edge";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            var e = cb.TakeDamage(6);
            cb.Particle(BattleManager.Effects.Slash);
            if (e > 0)
            {
                cb.ApplyEffect("frost", e);
                cb.Particle(BattleManager.Effects.Frost);
            }
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
