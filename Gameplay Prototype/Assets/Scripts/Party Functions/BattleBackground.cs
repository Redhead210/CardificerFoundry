/**
// File Name :         BattleBackround.cs
// Author :            Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Changes the backround depending on the act
**/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBackground : MonoBehaviour
{
    public Sprite act1;
    public Sprite act2;
    public Sprite act3;
    public Sprite act4;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.act == 0)
        {
            sr.sprite = act1;
        }
        else if (GameManager.act == 1)
        {
            sr.sprite = act2;
        }
        else if (GameManager.act == 2)
        {
            sr.sprite = act3;
        }
        else if (GameManager.act == -1)
        {
            sr.sprite = act1;
        }
        else
        {
            sr.sprite = act4;
        }
    }
}
