/**
// File Name :         ShopAudioSourceBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Handles the volume level in the main menu
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAudioSourceBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = GameManager.soundVolume;
    }
}
