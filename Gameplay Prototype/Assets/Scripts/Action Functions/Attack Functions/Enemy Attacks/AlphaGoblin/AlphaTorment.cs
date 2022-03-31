/**
// File Name :         AlphaTorment.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Torment attack alpha goblin
**/
using System.Collections.Generic;
using UnityEngine;

public class AlphaTorment : EnemyAttack
{
    public AlphaTorment()
    {
        target = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "AlphaTorment";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Torment";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        target.TakeDamage(7);
        target.Particle(BattleManager.Effects.Cogs);
        target.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
