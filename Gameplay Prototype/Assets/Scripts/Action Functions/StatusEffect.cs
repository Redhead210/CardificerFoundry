/**
// File Name :         StatusEffects.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the icons displayed for status effects
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect
{
    public int stacks;
    public string name;
    public Sprite icon;

    public StatusEffect(int stacks, string name)
    {
        this.stacks = stacks;
        this.name = name;

        var spriteList = Resources.LoadAll("Status Effect Icons", typeof(Sprite));
        foreach (Sprite s in spriteList)
        {
            if (s.name.Equals(name))
            {
                icon = s;
                break;
            }
        }
    }

}
