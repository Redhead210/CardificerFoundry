/**
// File Name :         BodyBlock.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that applies block to the lowest health enemy
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBlock : EnemyAttack
{
public BodyBlock()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "BodyBlock";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Defense };
    }
    public override string GetName()
    {
        return "Body Block";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        var t = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllEnemies());
        t.block += 5;
        t.Particle(BattleManager.Effects.Block);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
