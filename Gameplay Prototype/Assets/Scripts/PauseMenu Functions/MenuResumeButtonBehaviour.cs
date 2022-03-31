/**
// File Name :         MenuResumeButtonBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Enables the pause button
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResumeButtonBehaviour : MonoBehaviour
{
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Awake()
    {
        PauseMenu = GameObject.Find("PauseMenu");
    }

    public void SetPauseMenuInactive()
    {
        GameManager.gm.isPaused = false;
        PauseMenu.SetActive(false);
    }

}
