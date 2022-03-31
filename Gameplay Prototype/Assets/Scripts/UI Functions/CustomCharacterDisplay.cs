/**
// File Name :         CustomCharacterDisplay.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Displays the proper clothing on characters
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterDisplay : MonoBehaviour
{
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        if (character != null)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = character.body;
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = character.hat;
        }   
    }

    public void Refresh()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = character.body;
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = character.hat;
    }
}
