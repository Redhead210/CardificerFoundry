/**
// File Name :         Decontaminate.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that deals toxin to players and regen to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decontaminate : EnemyAttack
{
public Decontaminate()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Decontaminate";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff, Type.Buff };
    }
    public override string GetName()
    {
        return "Decontaminate";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("toxin", 3);
            c.Particle(BattleManager.Effects.Toxin);
        }

        caster.ApplyEffect("regen", 3);
        caster.Particle(BattleManager.Effects.Regen);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
