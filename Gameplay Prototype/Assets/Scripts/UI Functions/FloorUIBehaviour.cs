/**
// File Name :         FloorUIBehaviour.cs
// Author :            Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Handles the floor UI
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorUIBehaviour : MonoBehaviour
{
    private Text fortnite;

    // Start is called before the first frame update
    void Start()
    {
        fortnite = gameObject.GetComponent<Text>();
        fortnite.text = "Floor: " + GameManager.floor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
