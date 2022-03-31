/**
// File Name :         BurnEverything.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Burn Everything attack for Flamethrower
**/
using System.Collections.Generic;
using UnityEngine;

public class BurnEverything : EnemyAttack
{
    public BurnEverything()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "BurnEverything";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff };
    }
    public override string GetName()
    {
        return "Burn Everything!";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("burn", 5);
            c.Particle(BattleManager.Effects.Fire);
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("burn", 2);
            c.Particle(BattleManager.Effects.Fire);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
