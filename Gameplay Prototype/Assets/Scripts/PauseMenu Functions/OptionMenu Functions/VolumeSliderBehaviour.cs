/**
// File Name :         VolumeSliderBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Handles the slider for volume in the settings menu
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderBehaviour : MonoBehaviour
{
    public float VolumeSliderValue;
    public GameManager gm;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Slider>().value = GameManager.soundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.soundVolume = gameObject.GetComponent<Slider>().value;
        
    }
}
