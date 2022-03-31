/**
// File Name :         FullSteamAhead.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Applies haste asnd armor to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSteamAhead : EnemyAttack
{
public FullSteamAhead()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "FullSteamAhead";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Full Steam Ahead";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        caster.ApplyEffect("haste", 3);
        caster.ApplyEffect("armor", 3);
        caster.block += 4;
        caster.Particle(BattleManager.Effects.Smoke);
        caster.Particle(BattleManager.Effects.Block);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
