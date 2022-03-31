/**
// File Name :         LeadingCommand.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Leading Command attack for Flamethrower
**/
using System.Collections.Generic;
using UnityEngine;

public class LeadingCommand : EnemyAttack
{
    public LeadingCommand()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "LeadingCommand";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Leading Command";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("power", 1);
            c.Particle(BattleManager.Effects.Power);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
