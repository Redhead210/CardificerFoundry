/**
// File Name :         MenuOptionsButtonsBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Enables the menus
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptionsButtonBehaviour : MonoBehaviour
{
    public GameObject OptionsMenu;

    public void OpenOptionsMenu()
    {
        OptionsMenu.SetActive(true);
    }

    public void SetSceneToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
