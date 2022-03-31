using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eternity : EnemyAttack
{
public Eternity()
    {
	//Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "Eternity";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Eternity";
    }
    public override int GetSpeed()
    {
        return 99;
    }
    public override void UseAttack()
    {
        foreach(CharacterBehaviour cb in CharacterBehaviour.getAllAlive())
        {
            var e = cb.EffectStacks("frost");
            if (cb != caster && e > 0)
            {
                cb.TakeDamage(e,"Fade Away.");
            }
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
