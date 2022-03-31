/**
// File Name :         Wait.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Counts down for the snails powerful attack
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : EnemyAttack
{
    public Wait()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "Wait";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Wait...";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        caster.ShowMessage(6 - BattleManager.turns + " turns...",Color.gray);
    }

    public override bool CanBeUsed()
    {
        if (BattleManager.turns<6)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}