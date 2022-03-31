/**
// File Name :         TurretFire.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Turret Fire attack for goblin tank
**/
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : EnemyAttack
{
    public TurretFire()
    {
        //Set attack target here
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "TurretFire";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Turret Fire";
    }
    public override int GetSpeed()
    {
        return 10;
    }
    public override void UseAttack()
    {
        target.TakeDamage(10);
        target.ApplyEffect("burn", 2);
        target.Particle(BattleManager.Effects.Blast);
        target.Particle(BattleManager.Effects.Bullet);
    }

    public override bool CanBeUsed()
    {
        if (BattleManager.turns % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
