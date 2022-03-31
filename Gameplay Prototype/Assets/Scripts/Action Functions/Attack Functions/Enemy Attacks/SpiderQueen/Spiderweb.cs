/**
// File Name :         Spiderweb.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies frost and and toxin to an enemy and applies block to caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderweb : EnemyAttack
{
public Spiderweb()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Spiderweb";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff, Type.Defense};
    }
    public override string GetName()
    {
        return "Spiderweb";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            cb.ApplyEffect("frost", 3);
            cb.Particle(BattleManager.Effects.Frost);
            cb.ApplyEffect("toxin", 6);
            cb.Particle(BattleManager.Effects.Toxin);
        }

        caster.block += 16;
        caster.Particle(BattleManager.Effects.Block);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
