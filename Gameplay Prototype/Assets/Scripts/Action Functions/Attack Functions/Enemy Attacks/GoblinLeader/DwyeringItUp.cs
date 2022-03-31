/**
// File Name :         DwyeringItUp.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Powering up.. attack for goblin leader
**/
using System.Collections.Generic;
using UnityEngine;

public class DwyeringItUp : EnemyAttack
{
    public DwyeringItUp()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "DwyeringItUp";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Powering Up...";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("power", 2);
        caster.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
        if(caster.HasEffect("power"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
