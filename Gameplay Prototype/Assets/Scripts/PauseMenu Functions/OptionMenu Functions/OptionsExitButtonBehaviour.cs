/**
// File Name :         OptionsExitButtonBehaviour.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Opens and closes credits and how to play screens
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsExitButtonBehaviour : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;

    public void CloseOptionsMenu()
    {
        OptionsMenu.SetActive(false);
    }

    public void CloseCreditsMenu()
    {
        CreditsMenu.SetActive(false);
    }
}
