/**
// File Name :         ImmaGetcha.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Deals massive damage after 6 turns
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmaGetcha : EnemyAttack
{
    public ImmaGetcha()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "ImmaGetcha";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Imma Getcha";
    }
    public override int GetSpeed()
    {
        return 8;
    }

    public override void UseAttack()
    {
        target.TakeDamage(40);
        target.Particle(BattleManager.Effects.Blast);
        target.Particle(BattleManager.Effects.Smoke);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        if (BattleManager.turns>=6)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
