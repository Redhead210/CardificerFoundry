/**
// File Name :         MenuButtonBehaviour.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Loads scenes and changes variables
**/
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtonBehaviour : MonoBehaviour
{
    public void LoadMap()
    {
        GameManager.act = 0;
        SceneManager.LoadScene("Prep");
    }

    public void Tutorial()
    {
        GameManager.act = -1;
        SceneManager.LoadScene("Mission");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        TransitionManager.TransitionDown();
        if (TransitionManager.inMiddle == true)
        {
            
            SceneManager.LoadScene("Mission");
        }
        else
        {
            Invoke("LoadMenu", 0.0001f);
        }
    }

    public void ShopLoadMenu()
    {
        SceneManager.LoadScene("Mission");
    }

    public void SkipFloor()
    {
        GameManager.floor++;
        SceneManager.LoadScene("Mission");
    }

    public void SkipAct()
    {
        GameManager.act++;
        SceneManager.LoadScene("Mission");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
