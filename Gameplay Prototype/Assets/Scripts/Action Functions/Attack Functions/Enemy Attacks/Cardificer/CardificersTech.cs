/**
// File Name :CardificersTech.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : The Cardificers Tech attack
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersTech : EnemyAttack
{
    public CardificersTech()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "CardificersTech";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraTech";
        }
        else
        {
            return "Tech";
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
        }
        else
        {
            target.TakeDamage(10);
            BattleManager.innovate += 10;
        }
        
        target.Particle(BattleManager.Effects.Cogs);
        target.Particle(BattleManager.Effects.Cogs);
    }

    public override bool CanBeUsed()
    {
        if (CharacterBehaviour.GetCharAtIndex(true, 2).thisChar.hp > 400 || GameManager.phase2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
