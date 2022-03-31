/**
// File Name :CardificersIce.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : Cardificers Ice attack
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersIce : EnemyAttack
{
    public CardificersIce()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "CardificersIce";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraBlizzard";
        }
        else
        {
            return "Blizzard";
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
            target.TakeDamage(15);
            target.ApplyEffect("frost", 10);
        }
        else
        {
            target.TakeDamage(10);
            target.ApplyEffect("frost", 8);
        }
        
        target.Particle(BattleManager.Effects.Frost);
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
