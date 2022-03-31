/**
// File Name :         ToxicBrew.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Applies damage and toxin to allies
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicBrew : EnemyAttack
{
    public ToxicBrew()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "ToxicBrew";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() {  Type.Debuff, Type.Attack };
    }
    public override string GetName()
    {
        return "Toxic Brew";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        target.TakeDamage(3);
        target.ApplyEffect("toxin", 4);
        target.Particle(BattleManager.Effects.Toxin);
        target.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
        return true;
    }
}
