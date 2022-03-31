/**
// File Name :CardificersShadow.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : The Cardificers Shadow attack
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersShadow : EnemyAttack
{
    public CardificersShadow()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "CardificersShadow";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Buff };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraShadow";
        }
        else
        {
            return "Shadow";
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
            caster.ApplyEffect("haste", 6);
        }
        else
        {
            target.TakeDamage(8);
            caster.ApplyEffect("haste", 4);
        }
        
        target.Particle(BattleManager.Effects.Blood);
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
