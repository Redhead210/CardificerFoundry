/**
// File Name :         AlphaHarass.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Harass attack alpha harass
**/
using System.Collections.Generic;
using UnityEngine;

public class AlphaHarass : EnemyAttack
{
    public AlphaHarass()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "AlphaHarass";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Harass";
    }
    public override int GetSpeed()
    {
        return 3;
    }
    public override void UseAttack()
    {
        target.TakeDamage(8);
        target.Particle(BattleManager.Effects.Punch);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
