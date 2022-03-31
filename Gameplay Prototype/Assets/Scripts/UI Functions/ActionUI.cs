/**
// File Name :         ActionUI.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Manages the text that displays what characters are casting what cards
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionUI : MonoBehaviour
{

    public CharacterBehaviour caster;

    public Text txt;
    public Text txt2;

    // Update is called once per frame
    void Update()
    {
        var i = 0;
        foreach(AttackData a in BattleManager.queue)
        {
            i++;
            if (a.caster == caster)
            {
                txt.text = AttackUIBehaviour.intToStringPlace(i);
                txt2.text = a.aName;
                break;
            }
        }
    }
}
