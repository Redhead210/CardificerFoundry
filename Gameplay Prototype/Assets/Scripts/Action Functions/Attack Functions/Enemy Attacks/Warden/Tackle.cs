/**
// File Name :         Tackle.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Deals damage to target, and applies block to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : EnemyAttack
{
public Tackle()
    {
        //Set attack target here
        target = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "Tackle";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Defense};
    }
    public override string GetName()
    {
        return "Tackle";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        target.TakeDamage(4);
        caster.block += 6;
        caster.Particle(BattleManager.Effects.Block);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
