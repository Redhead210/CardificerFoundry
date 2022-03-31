/**
// File Name :         YouGetTheHorns.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : deals damage to the highest hp enemy 3 times
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouGetTheHorns : EnemyAttack
{
    public YouGetTheHorns()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "YouGetTheHorns";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "You Get The Horns";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        for (int i = 0; i < 3; i++)
        {
            var t = CharacterBehaviour.getHighestHP(CharacterBehaviour.getAllPlayers());
            t.Particle(BattleManager.Effects.Slash);
            t.Particle(BattleManager.Effects.Punch);
            t.TakeDamage(8);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
