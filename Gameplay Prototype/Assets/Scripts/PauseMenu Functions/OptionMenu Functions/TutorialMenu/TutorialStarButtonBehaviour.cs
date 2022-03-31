/**
// File Name :         TutorialStarButtonBehaviour.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Handles the activation of an object in the tutorial
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStarButtonBehaviour : MonoBehaviour
{
    public GameObject RespectiveTutorialObject;

    public void ActivateTutorialObject()
    {
        RespectiveTutorialObject.SetActive(true);
    }    

}
