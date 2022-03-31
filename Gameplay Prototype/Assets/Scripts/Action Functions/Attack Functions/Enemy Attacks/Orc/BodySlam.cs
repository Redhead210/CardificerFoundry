/**
// File Name :         BodySlam.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that deals damage and gains Taunt
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySlam : EnemyAttack
{
    public BodySlam()
    {
        target = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "BodySlam";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Buff };
    }
    public override string GetName()
    {
        return "Body Slam";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("taunt",1);
        target.TakeDamage(4);
        target.Particle(BattleManager.Effects.Punch);
        caster.Particle(BattleManager.Effects.Taunt);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}

