/**
// File Name :         Multiattack.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damage and posion to the highest hp player
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiattack : EnemyAttack
{
public Multiattack()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Multiattack";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Multiattack";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        for (int i = 0; i < 8; i++)
        {
            var t = GetHighestHPEnemy();
            t.TakeDamage(4);
            t.ApplyEffect("toxin", 4);
            t.Particle(BattleManager.Effects.Slash);
            t.Particle(BattleManager.Effects.Toxin);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
