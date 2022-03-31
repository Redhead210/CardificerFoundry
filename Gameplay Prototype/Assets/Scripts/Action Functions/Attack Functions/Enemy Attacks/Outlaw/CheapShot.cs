/**
// File Name :         CheapShot.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that deals three damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheapShot : EnemyAttack
{
    public CheapShot()
    {
        target = null;
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            if (c.HasEffect("mark"))
            {
                target = c;
                break;
            }
        }

        if (target == null)
        {
            target = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllPlayers());
        }
    }

    public override string GetClass()
    {
        return "CheapShot";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Cheap Shot";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        target.TakeDamage(3);
        target.Particle(BattleManager.Effects.Bullet);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
