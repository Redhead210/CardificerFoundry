/**
// File Name :         Torment.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals damage to the target
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torment : EnemyAttack
{
    public Torment()
    {
        target = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "Torment";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Torment";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        target.TakeDamage(3);
        target.Particle(BattleManager.Effects.Blood);
        target.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}

