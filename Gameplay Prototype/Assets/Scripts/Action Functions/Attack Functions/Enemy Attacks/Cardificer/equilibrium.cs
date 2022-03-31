/**
// File Name :equilibrium.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : destroys the others in the party, but heals the cardificer to full health
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equilibrium : EnemyAttack
{
    public equilibrium()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "equilibrium";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff, Type.Debuff };
    }
    public override string GetName()
    {
        return "Equilibrium";
    }
    public override int GetSpeed()
    {
        return 1;
    }
    public override void UseAttack()
    {
        var RightHand = CharacterBehaviour.GetCharAtIndex(true, 0);
        var LeftHand = CharacterBehaviour.GetCharAtIndex(true, 1);
        var health = caster.thisChar.maxhp - caster.thisChar.hp;


        caster.Heal(health);
        RightHand.TakeDamage(999);
        LeftHand.TakeDamage(999);
        caster.RemoveAllEffects();

        RightHand.Particle(BattleManager.Effects.Smoke);
        LeftHand.Particle(BattleManager.Effects.Smoke);
        caster.Particle(BattleManager.Effects.Regen);
        caster.thisChar.sprite = (Sprite)Resources.Load("CardificerPhase2.png");

        GameManager.phase2 = true;
    }

    public override bool CanBeUsed()
    {
        if (CharacterBehaviour.GetCharAtIndex(true, 2).thisChar.hp <= 250 && GameManager.phase2 == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}