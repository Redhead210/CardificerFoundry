/**
// File Name :         CrushingBlow.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : attack that deals damage to players and applies haste to enemies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBlow : EnemyAttack
{
public CrushingBlow()
    {
        target = GetRandomTarget();
    }

    public override string GetClass()
    {
        return "CrushingBlow";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Frenzy";
    }
    public override int GetSpeed()
    {
        return 8;
    }
    public override void UseAttack()
    {
        if (target.HasActed())
        {
            target.ShowMessage("Miss...", Color.blue);
            caster.ApplyEffect("haste", 1);
            caster.Particle(BattleManager.Effects.Blast);
        }
        else
        {
            target.TakeDamage(10, "SMASH!");
            target.SubtractEffect("haste", target.EffectStacks("haste"));
            caster.Particle(BattleManager.Effects.Blast);
            caster.Particle(BattleManager.Effects.Punch);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
