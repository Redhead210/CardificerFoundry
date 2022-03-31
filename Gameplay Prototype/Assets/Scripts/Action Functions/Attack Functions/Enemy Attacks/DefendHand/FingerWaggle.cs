/**
// File Name :         FingerWaggle.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : applies haste to all enemy allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class  FingerWaggle: EnemyAttack
{
    public FingerWaggle()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "FingerWaggle";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        return "Finger Waggle";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("haste", 3);
            c.Particle(BattleManager.Effects.Radience);
        }
    }

    public override bool CanBeUsed()
    {
        return true;

    }
}
