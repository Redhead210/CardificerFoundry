/**
// File Name :         Shockwave.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals 3 damage to each player/allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : EnemyAttack
{
public Shockwave()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Shockwave";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Shockwave";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.TakeDamage(3);
            c.Particle(BattleManager.Effects.Blast);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
