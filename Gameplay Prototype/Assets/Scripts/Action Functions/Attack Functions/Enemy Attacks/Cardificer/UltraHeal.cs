/**
// File Name :UltraHeal.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : Heals everyone in the party 1/8 of their max hp
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraHeal : EnemyAttack
{
    public UltraHeal()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "UltraHeal";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraLight";
        }
        else
        {
            return "Light";
        }
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
      foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            if (GameManager.phase2)
            {
                c.Heal(c.thisChar.maxhp / 7);
            }
            else
            {
                c.Heal(c.thisChar.maxhp / 8);
            }
            c.Particle(BattleManager.Effects.Regen);
        }
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
