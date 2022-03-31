/**
// File Name :         Battlecry.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that applies power to all enemies
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlecry : EnemyAttack
{
public Battlecry()
    {
	    //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Battlecry";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Battlecry";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour e in CharacterBehaviour.getAllEnemies())
        {
            e.ApplyEffect("power", 1);
            e.Particle(BattleManager.Effects.Power);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
