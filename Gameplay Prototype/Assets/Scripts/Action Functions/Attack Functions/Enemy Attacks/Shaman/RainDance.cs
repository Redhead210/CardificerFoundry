
/**
// File Name :         RainDance.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies toxin, bolck and health to enemy allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDance : EnemyAttack
{
public RainDance()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "RainDance";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Rain Dance";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour e in CharacterBehaviour.getAllEnemies())
        {
            e.block += 3;
            e.ApplyEffect("haste", 1);
            e.Particle(BattleManager.Effects.Toxin);
            e.Particle(BattleManager.Effects.Block);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
