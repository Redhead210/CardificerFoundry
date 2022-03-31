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
        foreach (EnemyGridMovement e in FindObjectsOfType<EnemyGridMovement>())
        {
            if (e.xp > 0)
            {
                GameManager.money += e.gold;
               
                foreach (Character c in Party.party)
                {
                    c.xp += e.xp;
                    
                    while (c.xp >= GameManager.XPtoLevel * c.level)
                    {
                        c.xp -= GameManager.XPtoLevel * c.level;
                        c.level++;
                        c.maxhp += c.hpmod;
                        c.hp += c.hpmod;
                    }
                }
            }
        }

        GameManager.floor++;
        if (GameManager.floor == 9)
        {
            GameManager.floor = 0;
            GameManager.act++;
        }

        SceneManager.LoadScene("Mission");
    }

    public void SkipAct()
    {
        GameManager.act++;
        SceneManager.LoadScene("Shop");
        foreach (Character c in Party.party)
        {
            c.xp += 240 * (GameManager.act*1);
            GameManager.money += 6000;
            while (c.xp >= GameManager.XPtoLevel * c.level)
            {
                c.xp -= GameManager.XPtoLevel * c.level;
                c.level++;
                c.maxhp += c.hpmod;
                c.hp += c.hpmod;
            }
        }
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
