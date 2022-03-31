/**
// File Name :CardificersMelee.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : The Cardificers melee attack
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersMelee : EnemyAttack
{
    public CardificersMelee()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "CardificersMelee";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraMelee";
        }
        else
        {
            return "Melee";
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
            target.TakeDamage(12);
            target.ApplyEffect("power", 4);
        }
        else
        {
            target.TakeDamage(10);
            target.ApplyEffect("power", 3);
        }
        target.Particle(BattleManager.Effects.Punch);
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
