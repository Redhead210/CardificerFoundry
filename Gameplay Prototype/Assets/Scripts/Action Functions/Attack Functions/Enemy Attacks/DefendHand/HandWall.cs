/**
// File Name :         HandWall.cs
// Author :            Will Bennington
// Creation Date :     October, 2021
//
// Brief Description : applies block and armor to all enemy allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWall : EnemyAttack
{
    public HandWall()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "HandWall";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense, Type.Buff };
    }
    public override string GetName()
    {
        return "Hand Wall";
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            c.ApplyEffect("armor", 3);
            c.block += 3;
            c.Particle(BattleManager.Effects.Block);
        }
    }

    public override bool CanBeUsed()
    {
        return true;

    }
}