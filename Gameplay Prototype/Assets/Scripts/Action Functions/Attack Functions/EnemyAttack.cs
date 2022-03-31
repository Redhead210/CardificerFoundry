/**
// File Name :         EnemyAttack.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : The basis of the indivigual enemy attacks
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack
{
    public enum Type {Attack, Defense, Buff, Debuff};

    public CharacterBehaviour target = null;
    public CharacterBehaviour caster;
    public abstract string GetClass();
    public abstract string GetName();
    public abstract List<Type> GetAttackType();
    public abstract void UseAttack();
    public abstract int GetSpeed();
    public abstract bool CanBeUsed();
    

    public static CharacterBehaviour GetRandomTarget()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        return pl[Random.Range(0, pl.Length)];
    }

    public static CharacterBehaviour GetHighestHPEnemy()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        return CharacterBehaviour.getHighestHP(pl);
    }

    public static CharacterBehaviour GetLowestHPEnemy()
    {
        CharacterBehaviour[] pl = CharacterBehaviour.getAllPlayers();
        return CharacterBehaviour.getLowestHP(pl);
    }
}
