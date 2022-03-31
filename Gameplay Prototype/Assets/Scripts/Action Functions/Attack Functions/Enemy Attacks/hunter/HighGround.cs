/**
// File Name :         HighGround.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : adds block to caster and apllies mark to party members
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighGround : EnemyAttack
{
public HighGround()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "HighGround";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Debuff, Type.Defense };
    }
    public override string GetName()
    {
        return "High Ground";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.ApplyEffect("mark", 2);
            c.Particle(BattleManager.Effects.Mark);
        }

        caster.block += 10;
        caster.Particle(BattleManager.Effects.Block);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
