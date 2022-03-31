/**
// File Name :         WingFlap.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : applies haste to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingFlap : EnemyAttack
{
    public WingFlap()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "WingFlap";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Wing Flap";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour e in CharacterBehaviour.getAllEnemies())
        {
            
            e.ApplyEffect("haste", 5);
            e.Particle(BattleManager.Effects.Smoke);
        }
    }

    public override bool CanBeUsed()
    {
        
        //If the attack has a special condition put it here
        return true;
    }
}
