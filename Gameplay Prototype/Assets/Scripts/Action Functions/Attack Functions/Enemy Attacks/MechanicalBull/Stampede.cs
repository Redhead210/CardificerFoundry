/**
// File Name :         Stampede.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage to target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stampede : EnemyAttack
{
public Stampede()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Stampede";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Stampede";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.TakeDamage(8);
            c.Particle(BattleManager.Effects.Blast);
            c.Particle(BattleManager.Effects.Punch);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
