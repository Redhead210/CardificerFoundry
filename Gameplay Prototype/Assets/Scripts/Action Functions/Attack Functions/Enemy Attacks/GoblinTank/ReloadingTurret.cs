/**
// File Name :         ReloadingTurret.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Reloading Turret attack for goblin tank
**/
using System.Collections.Generic;
using UnityEngine;

public class ReloadingTurret : EnemyAttack
{
    public ReloadingTurret()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "ReloadingTurret";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Reloading Turret";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        caster.ShowMessage("Reloading...", Color.gray);
        caster.Particle(BattleManager.Effects.Cogs);
    }

    public override bool CanBeUsed()
    {
        if (BattleManager.turns % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
