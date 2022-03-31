/**
// File Name :         BlockUIBehaviour.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Manages the block UI that appears next to the healthbar
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUIBehaviour : MonoBehaviour
{
    public int block;
    float uiBlock;

    public Sprite blockSpr;
    public Sprite blockSprBrk;

    Image img;
    Text txt;
    CanvasGroup cg;

    void Start()
    {
        img = GetComponentInChildren<Image>();
        txt = GetComponentInChildren<Text>();
        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiBlock < block)
        {
            uiBlock += 5 * Time.deltaTime;
        }

        if (uiBlock > block)
        {
            uiBlock -= 10 * Time.deltaTime;
        }

        txt.text = (Mathf.RoundToInt(uiBlock)).ToString();

        if (block == 0)
        {
            img.sprite = blockSprBrk;
        }
        else
        {
            img.sprite = blockSpr;
        }

        if (Mathf.CeilToInt(uiBlock) == 0)
        {
            cg.alpha = 0;
        }
        else
        {
            cg.alpha = 1;
        }
        
    }
}
