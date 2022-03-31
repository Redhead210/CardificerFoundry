/**
// File Name :         Skelegen.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Skelegen attack for skeleton
**/
using System.Collections.Generic;
using UnityEngine;

public class Skelegen : EnemyAttack
{
    public Skelegen()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "Skelegen";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Skelegen";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        caster.Heal(999);
        caster.Particle(BattleManager.Effects.Regen);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
