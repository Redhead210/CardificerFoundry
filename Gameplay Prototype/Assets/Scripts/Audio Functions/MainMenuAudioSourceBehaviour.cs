/**
// File Name :        MainMenuAudioSourceBehaviour.cs
// Author :            Tyler Colander
// Creation Date :     October, 2021
//
// Brief Description : Handles the Main Menu audio Sources
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAudioSourceBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            DontDestroyOnLoad(gameObject);
        }
        if(SceneManager.GetActiveScene().name != "Main Menu" && SceneManager.GetActiveScene().name != "Prep")
        {
            Destroy(gameObject);
        }


    }
}
