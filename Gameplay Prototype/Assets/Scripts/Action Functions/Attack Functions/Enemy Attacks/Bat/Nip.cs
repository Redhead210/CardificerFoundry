/**
// File Name :         Nip.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : deals low damage
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nip : EnemyAttack
{
    public Nip()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        target = pl[Random.Range(0, pl.Length)];
    }

    public override string GetClass()
    {
        return "Nip";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Attack };
    }
    public override string GetName()
    {
        return "Nip";
    }
    public override int GetSpeed()
    {
        return 2;
    }
    public override void UseAttack()
    {
        target.TakeDamage(4, "Nyah");
        target.Particle(BattleManager.Effects.Blood);
        target.Particle(BattleManager.Effects.Slash);
    }

    public override bool CanBeUsed()
    {
        //If the attack has a special condition put it here
        return true;
    }
}
