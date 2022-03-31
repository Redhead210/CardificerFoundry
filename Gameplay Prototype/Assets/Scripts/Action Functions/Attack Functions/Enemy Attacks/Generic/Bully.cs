/**
// File Name :         Bully.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that deals damage
**/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bully : EnemyAttack
{
    public Bully()
    {
        target = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "Bully";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Bully";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        target.TakeDamage(6);
        target.Particle(BattleManager.Effects.Blast);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}

