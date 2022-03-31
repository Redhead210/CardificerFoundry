/**
// File Name :         Entrench.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy Attack that deals damage to players, and gives enemies block
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrench : EnemyAttack
{
public Entrench()
    {
        //Set attack target here
        target = GetRandomTarget();
    }

    public override string GetClass()
    {
        return "Entrench";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Defense };
    }
    public override string GetName()
    {
        return "Entrench";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        var b = target.TakeDamage(6,"Dig!");
        target.Particle(BattleManager.Effects.Cogs);
        target.Particle(BattleManager.Effects.Slash);
        if (b > 0)
        {
            foreach(CharacterBehaviour cb in CharacterBehaviour.getAllEnemies())
            {
                cb.block += b;
                cb.Particle(BattleManager.Effects.Block);
            }
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
