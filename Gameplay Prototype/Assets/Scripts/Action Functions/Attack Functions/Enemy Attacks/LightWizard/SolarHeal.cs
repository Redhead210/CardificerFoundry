/**
// File Name :         SolarHeal.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Heals enemy allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarHeal : EnemyAttack
{
    public SolarHeal()
    {
        target = null;
    }

    public override string GetClass()
    {
        return "SolarHeal";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Solar Heal";
    }
    public override int GetSpeed()
    {
        return 9;
    }
    public override void UseAttack()
    {
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.Heal(15);
            c.Particle(BattleManager.Effects.Radience);
        }
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}