/**
// File Name :         GridTutorial.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Handles the tutorial setup
**/
using UnityEngine;
using UnityEngine.UI;

public class GridTutorial : MonoBehaviour
{
    public GameObject TutorialBox;
    public Text TutorialText;
    private int posText = 0;
    private bool trapAlready = false;
    private bool leverAlready = false;
    private bool enemyStartAlready = false;
    private bool xpAlready = false;
    private bool chestAlready = false;
    private bool finishAlready = false;
    private bool bruh = true;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.act == -1)
        {
            TutorialBox.SetActive(true);
            GameManager.inTutorialText = true;
            TutorialText.text = "Welcome to Cardificer's Foundry!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.act == -1)
        {
            var newX = FindObjectOfType<PlayerGridControl>().tile_x;
            var newY = FindObjectOfType<PlayerGridControl>().tile_y;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                bruh = !bruh;
            }

            if (Input.GetKeyDown(KeyCode.Space) && TutorialBox.activeInHierarchy && bruh)
            {
                posText++;
            }

            if (posText == 1)
            {
                TutorialText.text = "You can move around using the arrow keys and/or WASD.";
            }

            if (posText == 10)
            {
                TutorialText.text = "Above this sign you can see the party members stats.";
            }

            if (posText == 11)
            {
                TutorialText.text = "Below this sign you can see things like the amount of cogs you have.";
            }

            if (posText == 16)
            {
                TutorialText.text = "Stepping on this will take you to the next floor!";
            }

            if (posText == 16)
            {
                TutorialText.text = "However, since this is the tutorial, it'll take you back to the Main Menu.";
            }

            if (posText == 17)
            {
                TutorialText.text = "Thanks for playing the tutorial and I hope you enjoy Cardificer's Foundry!";
            }

            if (posText == 2 || posText == 4 || posText == 6 || posText == 8 ||
                posText == 12 || posText == 14 || posText == 18)
            {
                GameManager.inTutorialText = false;
                TutorialBox.SetActive(false);
                posText++;
            }

            if (newX == 3 && newY == 2 && !trapAlready)
            {
                trapAlready = true;
                GameManager.inTutorialText = true;
                TutorialBox.SetActive(true);
                TutorialText.text = "Make sure you watch out for traps! They hurt!";
            }

            if (((newX == 3 && newY == 4) || (newX == 4 && newY == 4)) && !leverAlready)
            {
                leverAlready = true;
                GameManager.inTutorialText = true;
                TutorialBox.SetActive(true);
                TutorialText.text = "Activate levers to open up secret passages!";
            }

            if (newX == 4 && newY == 9 && !enemyStartAlready)
            {
                enemyStartAlready = true;
                GameManager.inTutorialText = true;
                TutorialBox.SetActive(true);
                TutorialText.text = "There are enemies on each map, getting near them will start a battle!";
            }

            if (newX == 5 && newY == 9 && !xpAlready)
            {
                xpAlready = true;
                GameManager.inTutorialText = true;
                TutorialBox.SetActive(true);
                TutorialText.text = "After beating enemies, you will get cogs(money) and xp!";
            }

            if (newX == 7 && newY == 9 && !chestAlready)
            {
                chestAlready = true;
                GameManager.inTutorialText = true;
                TutorialBox.SetActive(true);
                TutorialText.text = "A chest! You can find some loot in here!";
            }

            if (((newX == 7 && newY == 5) || (newX == 8 && newY == 6)) && !finishAlready)
            {
                finishAlready = true;
                GameManager.inTutorialText = true;
                TutorialBox.SetActive(true);
                TutorialText.text = "This green space is the exit of the floor!";
            }
        }
    }
}
