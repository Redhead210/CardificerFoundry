/**
// File Name :         MoneyUIBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Updates the cog UI
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUIBehaviour : MonoBehaviour
{

    public GameManager gm;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Cogs: " + GameManager.money;
    }
}
