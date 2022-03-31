/**
// File Name :         Mudball.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damage and toxin
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudball : EnemyAttack
{
public Mudball()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Mudball";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Mudball";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        var s = "";
        if (target.block == 0)
        {
            s = "MUCK!";
        }

        target.TakeDamage(1,s);
        target.Particle(BattleManager.Effects.Toxin);
        if (target.block <= 0)
        {
            target.ApplyEffect("toxin", 2);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
