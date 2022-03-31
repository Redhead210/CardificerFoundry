/**
// File Name :         Fortress.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Applies block to each enemy
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : EnemyAttack
{
public Fortress()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Fortress";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense };
    }
    public override string GetName()
    {
        return "Fortress";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.block += 6;
            c.Particle(BattleManager.Effects.Smoke);
            c.Particle(BattleManager.Effects.Block);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
