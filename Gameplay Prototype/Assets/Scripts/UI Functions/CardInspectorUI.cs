/**
// File Name :         CardInspectorUI.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Operates the card inspector
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInspectorUI : MonoBehaviour
{
    public CardUI main;
    public CardUI next;
    public CardUI next1;
    public string cname;
    public int rank;
    public Text text;
    public Text flavor;
    
    void Start()
    {
        main.card = Card.stringToCard(cname, 1);
        next.card = Card.stringToCard(cname, 2);
        next1.card = Card.stringToCard(cname, 3);
        flavor.text = main.card.FlavorText();

        var tooltips = new List<string>();
        var d = main.card.cardDesc().ToLower();

        if (d.Contains("block"))
        {
            tooltips.Add("[Block]: Temporary hitpoints that are reduced by half at the end of each turn.");
        }
        if (d.Contains("frost"))
        {
            tooltips.Add("[Frost]: Reduces the speed of actions by the amount of Frost on a character.");
        }
        if (d.Contains("burn"))
        {
            tooltips.Add("[Burn]: A character takes damage equal to their Burn at the end of the turn, then their Burn is reduced by 1.");
        }
        if (d.Contains("poison"))
        {
            tooltips.Add("[Poison]: If a character has Poison they take 3 damage at the end of the turn, then their Poison is reduced by 1.");
        }
        if (d.Contains("mark"))
        {
            tooltips.Add("[Mark]: When a character with Mark takes damage, the damage is doubled and their Mark is reduced by 1.");
        }
        if (d.Contains("power"))
        {
            tooltips.Add("[Power]: When a character deals damage, it is increased by their Power.");
        }
        if (d.Contains("regen"))
        {
            tooltips.Add("[Regen]: A character heals equal to their Regen at the end of the turn, then their Regen is reduced by 1.");
        }
        if (d.Contains("innovate"))
        {
            tooltips.Add("[Innovate]: When a card Innovates, the number in brackets is increased for other Tech cards for the rest of the battle.");
        }
        if (d.Contains("haste"))
        {
            tooltips.Add("[Haste]: Increases the speed of actions by the amount of Haste on a character.");
        }
        if (d.Contains("radiance"))
        {
            tooltips.Add("[radiance]: When a character with radiance is healed, all opposing characters take damage equal to their radiance.");
        }
        if (d.Contains("taunt"))
        {
            tooltips.Add("[Taunt]: Redirects all targeted attacks to a character with Taunt. Only one character on a side can have Taunt at a time. Reduces by 1 at the end of the turn.");
        }

        var t = "";
        foreach(string s in tooltips)
        {
            t += s + "\n\n";
        }

        text.text = t;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && GameManager.gm.isPaused == false)
        {
            Destroy(gameObject);
        }
    }
}
