/**
// File Name :         Demolition.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : attack that breaks block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolition : EnemyAttack
{
public Demolition()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Demolition";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Demolition";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            cb.Particle(BattleManager.Effects.Blast);
            if (cb.block > 0)
            {
                cb.TakeDamage(cb.block, "Block Broken!");
            }
            else
            {
                cb.TakeDamage(8, "BOOM!");
                cb.Particle(BattleManager.Effects.Fire);
            }
        }
    }

    public override bool CanBeUsed()
    {
	    foreach (AttackData a in BattleManager.queue)
        {
            if (a.aName.Equals("Demolition"))
            {
                return false;
            }
        }

        return true;
    }
}
