/**
// File Name :         BulletHell.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that deals damage to all characters based on how much mark they have
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : EnemyAttack
{
public BulletHell()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "BulletHell";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Bullet Hell";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            while (c.HasEffect("mark"))
            {
                c.TakeDamage(2,"DIE!");
                c.Particle(BattleManager.Effects.Bullet);
            }
        }
    }

    public override bool CanBeUsed()
    {
        var m = 0;
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            m += c.EffectStacks("mark");
        }
        return m >= 5;
    }
}
