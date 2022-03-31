/**
// File Name :CardificersCure.cs
// Author :            Will Bennington
// Creation Date :     12/1/2021
//
// Brief Description : Cures all effects from the Cardificer
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardificersCure : EnemyAttack
{
    public CardificersCure()
    {
        //Set attack target here
        target = null;
    }

    public override string GetClass()
    {
        return "CardificersCure";
    }
    public override List<Type> GetAttackType()
    {
        return new List<Type>() { Type.Buff };
    }
    public override string GetName()
    {
        if(GameManager.phase2)
        {
            return "UltraCure";
        }
        else
        {
            return "Cure";
        }
        
    }
    public override int GetSpeed()
    {
        return 5;
    }
    public override void UseAttack()
    {
        caster.RemoveAllEffects();
        caster.Particle(BattleManager.Effects.Regen);
    }

    public override bool CanBeUsed()
    {
        if(((CharacterBehaviour.GetCharAtIndex(true,2).EffectStacks("burn") !=0 ||
            CharacterBehaviour.GetCharAtIndex(true, 2).EffectStacks("toxin") !=0 ||
            CharacterBehaviour.GetCharAtIndex(true, 2).EffectStacks("frost") !=0 ||
            CharacterBehaviour.GetCharAtIndex(true, 2).EffectStacks("mark") != 0 )) &&
            CharacterBehaviour.GetCharAtIndex(true, 2).thisChar.hp > 250 || GameManager.phase2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
