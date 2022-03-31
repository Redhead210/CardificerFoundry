using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ironclad : EnemyAttack
{
public Ironclad()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Ironclad";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Defense };
    }
    public override string GetName()
    {
        return "Ironclad";
    }
    public override int GetSpeed()
    {
        return 4;
    }
    public override void UseAttack()
    {
        caster.Particle(BattleManager.Effects.Cogs);
        caster.Particle(BattleManager.Effects.Block);
        caster.block += 15;
        caster.ApplyEffect("power", 2);
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
