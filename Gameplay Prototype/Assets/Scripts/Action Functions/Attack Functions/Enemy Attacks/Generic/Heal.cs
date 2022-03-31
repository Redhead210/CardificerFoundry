/**
// File Name :         Heal.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Heals the lowest health enemy
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : EnemyAttack
{
public Heal()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Heal";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Heal";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        target = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllEnemies());
        target.Heal(2);
        target.Particle(BattleManager.Effects.Regen);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }

    
}
