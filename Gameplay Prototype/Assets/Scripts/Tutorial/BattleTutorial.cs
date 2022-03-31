/**
// File Name :         BattleTutorial.cs
// Author :           Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Handles battle tutorial
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTutorial : MonoBehaviour
{
    public GameObject TutorialBox;
    public Text TutorialText;
    private int posText = 0;
    public static bool inDialogue = false;
    private bool bruh = true;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.act == -1)
        {
            inDialogue = true;
            TutorialBox.SetActive(true);
            GameManager.inTutorialText = true;
            TutorialText.text = "Here we are in battle. We have here one enemy!";

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.act == -1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bruh = !bruh;
            }

            if (Input.GetKeyDown(KeyCode.Space) && TutorialBox.activeInHierarchy && bruh)
            {
                posText++;
            }

            if (posText == 1)
            {
                TutorialText.text = "We have our two party members on the left and the enemy party on the right.";
            }

            if (posText == 2)
            {
                TutorialText.text = "Our party's methods of attack (Cards) are drawn at the bottom.";
            }

            if (posText == 3)
            {
                TutorialText.text = "You are able to click on your party's stands to see what cards they can place.";
            }

            if (posText == 4)
            {
                TutorialText.text = "Right-clicking them will show in greater detail what they do.";
            }

            if (posText == 5)
            {
                TutorialText.text = "Every character has two types, indicated by the emblems here.";
                arrow1.SetActive(true);
            }

            if (posText == 6)
            {
                TutorialText.text = "Each card has a certain type, indicating who can play that card.";
                arrow1.SetActive(false);
            }

            if (posText == 7)
            {
                TutorialText.text = "Each card also has a certain speed, indicating by the number at the top of it.";
            }

            if (posText == 8)
            {
                TutorialText.text = "Every card played (including enemy cards) is put into a queue at the end of the turn.";
            }

            if (posText == 9)
            {
                TutorialText.text = "The lower the number, the closer it is to the front of the queue.";
            }

            if (posText == 10)
            {
                TutorialText.text = "Here, we have these gray cards, which means that anyone can play them.";
                arrow2.SetActive(true);
            }

            if (posText == 11)
            {
                TutorialText.text = "This card here is a melee card type, meaning only melee party members can play it.";
                arrow2.SetActive(false);
                arrow3.SetActive(true);
            }

            if (posText == 12)
            {
                TutorialText.text = "This card here is an iconic card type, specific to your main hero.";
                arrow3.SetActive(false);
                arrow4.SetActive(true);
            }

            if (posText == 13)
            {
                TutorialText.text = "In this case, 'The Guardian'";
            }

            if (posText == 14)
            {
                TutorialText.text = "In order to use a card, drag it onto the characters.";
                arrow4.SetActive(false);
            }

            if (posText == 15)
            {
                TutorialText.text = "The character stands will light up to signify where they can be used.";
            }

            if (posText == 16)
            {
                TutorialText.text = "Go ahead and play cards to defeat the enemy!";
            }

            if (posText == 17)
            {
                TutorialBox.SetActive(false);
                GameManager.inTutorialText = false;
                inDialogue = false;
            }
        }
    }
}
