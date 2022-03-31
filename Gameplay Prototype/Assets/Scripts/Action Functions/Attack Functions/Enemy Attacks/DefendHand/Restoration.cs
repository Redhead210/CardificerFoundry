
/**
// File Name :         Restoration.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : Heals and appiles regen to all enemy allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Restoration : EnemyAttack
{
    public Restoration()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Restoration";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Restoration";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.Heal(5);
            c.ApplyEffect("regen", 2);
            c.Particle(BattleManager.Effects.Regen);
        }
    }

    public override bool CanBeUsed()
    {
        return true;

    }
}
