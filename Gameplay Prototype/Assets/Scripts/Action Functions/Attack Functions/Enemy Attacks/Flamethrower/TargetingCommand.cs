/**
// File Name :         TargetingCommand.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Targeting Command attack for Flamethrower
**/
using System.Collections.Generic;
using UnityEngine;

public class TargetingCommand : EnemyAttack
{
    public TargetingCommand()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "TargetingCommand";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff };
    }
    public override string GetName()
    {
        return "Targeting Command";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("mark", 1);
            c.Particle(BattleManager.Effects.Mark);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
