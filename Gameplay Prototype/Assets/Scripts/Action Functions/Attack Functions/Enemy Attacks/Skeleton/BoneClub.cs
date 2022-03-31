/**
// File Name :         BoneClub.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Bone Club attack for skeleton
**/
using System.Collections.Generic;
using UnityEngine;

public class BoneClub : EnemyAttack
{
    public BoneClub()
    {
        target = CharacterBehaviour.getLowestHP(CharacterBehaviour.getAllPlayers());
    }

    public override string GetClass()
    {
        return "BoneClub";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Bone Club";
    }
    public override int GetSpeed()
    {
        return 4;
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
