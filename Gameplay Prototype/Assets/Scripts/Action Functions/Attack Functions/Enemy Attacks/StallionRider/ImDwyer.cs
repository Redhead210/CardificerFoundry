/**
// File Name :         ImDwyer.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Stampede attack for Stallion
**/
using System.Collections.Generic;
using UnityEngine;

public class ImDwyer : EnemyAttack
{
    public ImDwyer()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "ImDwyer";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Stampede";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.TakeDamage(4);
            c.Particle(BattleManager.Effects.Punch);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
