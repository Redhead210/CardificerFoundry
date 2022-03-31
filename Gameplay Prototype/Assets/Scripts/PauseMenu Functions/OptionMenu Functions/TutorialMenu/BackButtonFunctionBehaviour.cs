/**
// File Name :         BackButtonFunctionBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October 2021
//
// Brief Description : Turns off options menu
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonFunctionBehaviour : MonoBehaviour
{
    public GameObject ParentObject;
    public void TurnOffParentObject()
    {
        ParentObject.SetActive(false);
    }
}
