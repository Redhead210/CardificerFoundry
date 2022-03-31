/**
// File Name :         Succumb.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : takes damage based on the status effects on the target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succumb : EnemyAttack
{
public Succumb()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Succumb";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Succumb";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            var d = 0;
            foreach(StatusEffect s in cb.statusEffects)
            {
                d += s.stacks;
            }

            if (d > 0)
            {
                cb.TakeDamage(d, "Weak...");
                cb.Particle(BattleManager.Effects.Slash);
            }
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
