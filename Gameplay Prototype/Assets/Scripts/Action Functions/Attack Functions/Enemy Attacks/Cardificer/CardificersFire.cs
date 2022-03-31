/**
// File Name :CardificersFire.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : The Cardificers Fire attack
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersFire : EnemyAttack
{
    public CardificersFire()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "CardificersFire";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraFlame";
        }
        else
        {
            return "Flame";
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
            target.TakeDamage(13);
            target.ApplyEffect("burn", 4);
        }
        else
        {
            target.TakeDamage(9);
            target.ApplyEffect("burn", 3);
        }
        
        target.Particle(BattleManager.Effects.Smoke);
        target.Particle(BattleManager.Effects.Cogs);
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
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
