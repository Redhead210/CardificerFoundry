/**
// File Name :         ColdSteel.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that applies damage and frost
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdSteel : EnemyAttack
{
public ColdSteel()
    {
        //Set attack target here
        target = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "ColdSteel";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Cold Steel";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.ApplyEffect("frost", 3);
        target.TakeDamage(2, "3T3RNAL.");
        target.Particle(BattleManager.Effects.Frost);
        target.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
