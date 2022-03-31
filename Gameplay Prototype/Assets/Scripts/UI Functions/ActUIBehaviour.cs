/**
// File Name :         ActUIBehaviour.cs
// Author :            Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Determines the act line of the Game UI
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActUIBehaviour : MonoBehaviour
{
    private Text bigChungus;

    // Start is called before the first frame update
    void Start()
    {
        //identifying the proper portion of the UI
        bigChungus = gameObject.GetComponent<Text>();
        //setting the UI to the proper value
        bigChungus.text = "Act: " + (int)(GameManager.act + 1);
    }
}
