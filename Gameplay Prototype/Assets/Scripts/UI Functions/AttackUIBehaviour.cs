/**
// File Name :         AttackUIBehaviour.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Displays the text and image that pops up above enemies to show their upcoming attack
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUIBehaviour : MonoBehaviour
{
    public CharacterBehaviour caster;
    CanvasGroup cg;
    public bool fade = true;

    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            if (cg.alpha < 1)
            {
                cg.alpha += 5 * Time.deltaTime;
            }
        }
        else
        {
            if (cg.alpha > 0)
            {
                cg.alpha -= 5 * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (caster != null)
        {
            var i = 0;
            foreach(AttackData a in BattleManager.queue)
            {
                i++;
                if (a.caster == caster)
                {
                    if (a.thisAttack.GetAttackType().Contains(EnemyAttack.Type.Attack))
                    {
                        transform.GetChild(3).gameObject.SetActive(true);
                    }
                    if (a.thisAttack.GetAttackType().Contains(EnemyAttack.Type.Defense))
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                    }
                    if (a.thisAttack.GetAttackType().Contains(EnemyAttack.Type.Buff))
                    {
                        transform.GetChild(2).gameObject.SetActive(true);
                    }
                    if (a.thisAttack.GetAttackType().Contains(EnemyAttack.Type.Debuff))
                    {
                        transform.GetChild(1).gameObject.SetActive(true);
                    }

                    var t = GetComponentsInChildren<Text>();
                    t[0].text = intToStringPlace(i);
                    t[1].text = a.thisAttack.GetName();

                    break;
                }
            }
            
        }
    }

    public static string intToStringPlace(int i)
    {
        var m = i % 10;

        switch(m)
        {
            case 1: return i + "st";
            case 2: return i + "nd";
            case 3: return i + "rd";
            default: return i + "th";
        }
    }
}
