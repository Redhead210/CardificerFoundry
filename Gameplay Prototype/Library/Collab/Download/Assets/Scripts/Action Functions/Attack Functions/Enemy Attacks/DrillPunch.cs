using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillPunch : EnemyAttack
{
public DrillPunch()
    {
	//Set attack target here
        target = GetHighestHPEnemy();
    }

    public override string GetClass()
    {
        return "Drill-Punch";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "DrillPunch";
    }
    public override int GetSpeed()
    {
        return 7;
    }
    public override void UseAttack()
    {
        for (int i = 0; i < 3+BattleManager.turns; i++)
        {
            target.TakeDamage(2);
        }
    }

    public override bool CanBeUsed()
    {
	//If the attack has a special condition put it here
        return true;
    }
}
