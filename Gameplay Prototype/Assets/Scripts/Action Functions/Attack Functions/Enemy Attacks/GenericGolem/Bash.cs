/**
// File Name :         Bash.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Enemy attack that deals damage based on block
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : EnemyAttack
{
    public Bash()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Bash";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack, Type.Defense };
    }
    public override string GetName()
    {
        return "Bash";
    }
    public override int GetSpeed()
    {
        return 6;
    }
    public override void UseAttack()
    {
        caster.block += 4;
        caster.Particle(BattleManager.Effects.Block);
        target.TakeDamage(caster.block,"Blocked!");
        target.Particle(BattleManager.Effects.Block);
        target.Particle(BattleManager.Effects.Punch);
        
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}

