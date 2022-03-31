/**
// File Name :         AttackData.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Class that holds the data for attacks that get put in the queue.
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackData : IComparable
{
    public enum Side {Player, Enemy}

    public string aName;
    public string aClass;
    public int speed;
    public Side allignment;
    public CharacterBehaviour caster;
    public CharacterBehaviour target;
    public bool targeting = false;

    public Card thisCard = null;
    public EnemyAttack thisAttack = null;

    public AttackData(Card card, CharacterBehaviour caster, CharacterBehaviour target = null)
    {
        aName = card.cardName();
        aClass = card.cardClass();
        speed = card.cardSpeed();

        allignment = Side.Player;

        this.caster = caster;
        this.target = target;

        thisCard = card;

        if (card.cardTarget() != Card.Targets.None)
        {
            targeting = true;
        }
        
        thisCard.caster = caster;
    }

    public AttackData(EnemyAttack atk, CharacterBehaviour caster)
    {
        aName = atk.GetName();
        aClass = atk.GetClass();
        speed = atk.GetSpeed();

        allignment = Side.Enemy;

        this.caster = caster;
        this.target = atk.target;

        thisAttack = atk;
        
        thisAttack.caster = caster;
        
    }

    public int CompareTo(System.Object @object)
    {
        var a = (AttackData)@object;
        return (speed+caster.EffectStacks("frost") - caster.EffectStacks("haste")) - (a.speed + a.caster.EffectStacks("frost") - a.caster.EffectStacks("haste"));
    }

    public void Cast()
    {
        if (allignment == Side.Player)
        {
            if (target != null && target.isEnemy == true)
            {
                foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
                {
                    if (c.HasEffect("taunt"))
                    {
                        target = c;
                    }
                }
            }

            thisCard.castCard(target);
        }
        else
        {
            if (thisAttack.target != null && target.isEnemy == false)
            {
                foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
                {
                    if (c.HasEffect("taunt"))
                    {
                        thisAttack.target = c;
                        break;
                    }
                }
            }
            thisAttack.UseAttack();
        }
    }
}


