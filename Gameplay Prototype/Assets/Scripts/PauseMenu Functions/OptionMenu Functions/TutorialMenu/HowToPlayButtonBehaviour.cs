/**
// File Name :         HowToPlayButtonBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Enables the How to Play object
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButtonBehaviour : MonoBehaviour
{
    public GameObject HowToPlayObject;

    public void ActivateHowToPlay()
    {
        HowToPlayObject.SetActive(true);
    }
}
