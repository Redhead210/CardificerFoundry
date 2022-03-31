/**
// File Name :         InnovationBlast.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : deals damage based on 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnovationBlast : EnemyAttack
{
    public InnovationBlast()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "InnovationBlast";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Innovation Blast";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        
        target.TakeDamage(BattleManager.innovate+5, "Whack");
        target.Particle(BattleManager.Effects.Blast);
        BattleManager.innovate = 0;
    }

    public override bool CanBeUsed()
    {
        if (BattleManager.innovate>=8)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }
}
