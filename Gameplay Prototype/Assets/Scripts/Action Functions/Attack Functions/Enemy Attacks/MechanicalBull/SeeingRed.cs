
/**
// File Name :         SeeingRed.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Applies Haste and power to the caster
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingRed : EnemyAttack
{
    public SeeingRed()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "SeeingRed";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Seeing Red";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        int p = (caster.thisChar.maxhp - caster.thisChar.hp) / 50;
        caster.ApplyEffect("power", p);
        caster.ApplyEffect("armor", p);
        caster.block += p * 5;
        caster.Particle(BattleManager.Effects.Blood);
        caster.Particle(BattleManager.Effects.Cogs);
        caster.Particle(BattleManager.Effects.Power);
    }

    public override bool CanBeUsed()
    {
        return CharacterBehaviour.getAllEnemies()[0].thisChar.hp < 400;
    }
}

