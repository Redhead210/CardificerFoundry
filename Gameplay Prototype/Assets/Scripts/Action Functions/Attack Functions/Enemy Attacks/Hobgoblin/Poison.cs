/**
// File Name :         Posion.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies toxin
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : EnemyAttack
{
public Poison()
    {
        target = GetRandomTarget();
    }

    public override string GetClass()
    {
        return "Poison";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff };
    }
    public override string GetName()
    {
        return "Poison";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        target.ApplyEffect("toxin", 5);
        target.Particle(BattleManager.Effects.Toxin);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
