
/**
// File Name :         HackNSlash.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Causes the players with the highest and lowest health to take damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackNSlash : EnemyAttack
{
public HackNSlash()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "HackNSlash";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Hack N' Slash";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        var t = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllPlayers());
        t.TakeDamage(6);
        t.Particle(BattleManager.Effects.Slash);
        t = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllPlayers());
        t.TakeDamage(6);
        t.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
