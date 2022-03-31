using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepingEdge : EnemyAttack
{
public SweepingEdge()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "SweepingEdge";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Debuff };
    }
    public override string GetName()
    {
        return "Freezing Edge";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour cb in CharacterBehaviour.getAllPlayers())
        {
            var e = cb.TakeDamage(6);
            if (e > 0)
            {
                cb.ApplyEffect("frost", e);
            }
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
