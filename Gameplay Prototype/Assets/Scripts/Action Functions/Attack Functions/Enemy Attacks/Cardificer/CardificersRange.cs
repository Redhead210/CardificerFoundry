/**
// File Name :CardificersRange.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : The Cardificers Range attack
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersRange : EnemyAttack
{
    public CardificersRange()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "CardificersRange";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        if (GameManager.phase2)
        {
            return "UltraFirearm";
        }
        else
        {
            return "Firearm";
        }
            
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        if(GameManager.phase2)
        {
            target.TakeDamage(11);
            target.ApplyEffect("mark", 3);
        }
        else
        {
            target.TakeDamage(9);
            target.ApplyEffect("mark", 2);
        }
        
        target.Particle(BattleManager.Effects.Mark);
        target.Particle(BattleManager.Effects.Cogs);
    }

    public override bool CanBeUsed()
    {
        if (CharacterBehaviour.GetCharAtIndex(true, 2).thisChar.hp > 250 || GameManager.phase2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}