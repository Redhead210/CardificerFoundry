/**
// File Name :         StatusEffectUIBehaviour.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the numbers and text for status effects
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatusEffectUIBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int SEArrayIndex;
    public CharacterBehaviour cb;
    public Image img;
    public Text txt;
    public Text txt1;


    // Start is called before the first frame update
    void Start()
    {
        txt1.enabled = false;
    }

    

    public static StatusEffectUIBehaviour GetStatusUIofType(CharacterBehaviour cb, string name)
    {
        var a = cb.GetCBStatusUI();
        foreach (StatusEffectUIBehaviour ui in a)
        {
            if (cb.statusEffects[ui.SEArrayIndex].name.Equals(name))
            {
                return ui;
            }
        }

        return null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        txt1.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        txt1.enabled = false;
    }
}
