
/**
// File Name :         RockMace.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : deals damage to players
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMace : EnemyAttack
{ 
public RockMace()
{
    //Set attack target here
    CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
    target = pl[Random.Range(0, pl.Length)];
}

public override string GetClass()
{
    return "RockMace";
}
public override List<Type> GetAttackType()
{
    return new List<Type>() { Type.Attack };
}
public override string GetName()
{
    return "Rock Mace";
}
public override int GetSpeed()
{
    return 5;
}
public override void UseAttack()
{
    var s = "";
    if (target.block == 0)
    {
        s = "BAM";
    }

    target.TakeDamage(6, s);
    target.Particle(BattleManager.Effects.Slash);

    }

public override bool CanBeUsed()
{
    //If the attack has a special condition put it here
    return true;
}
}

