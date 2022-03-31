/**
// File Name :         ScolutionForDeckSwap.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the swapping of cards and deck slots
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionForDeckSwap : MonoBehaviour
{
    public GameObject deckswap;
    public Character[] playerCharacters;
    Character rngCharacter;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        rngCharacter = Character.CharacterGen(1);
        Invoke("DoTheThing", 0.01f);
    }

    void DoTheThing() {
        Party.party[0] = playerCharacters[0].Clone();
        Party.party[1] = rngCharacter.Clone();
        //Party.party[1] = new Character(20, "TechMan", new Card.CardTypes[] { Card.CardTypes.Tech, Card.CardTypes.Fire }, new string[] { "Specialist", "Specialist", "Specialist", "Strike", "Defend", "Strike", "Defend", "Strike"});

        Instantiate(deckswap,new Vector2(9, -7.72f),Quaternion.identity);
    }

    public void ShiftLeft()
    {
        index--;
        if (index == -1)
        {
            index = playerCharacters.Length - 1;
        }

        RefreshParty();
    }

    public void ShiftRight()
    {
        index++;
        if (index == playerCharacters.Length)
        {
            index = 0;
        }

        RefreshParty();
    }

    void RefreshParty()
    {
        Party.party[0] = playerCharacters[index].Clone();
        Party.party[1] = rngCharacter.Clone();

        Destroy(GameObject.Find("DeckSwap(Clone)"));

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ShopUI"))
        {
            Destroy(obj);
        }

        var o = Instantiate(deckswap, new Vector2(9, -7.72f), Quaternion.identity);
        //o.GetComponent<RectTransform>().position = new Vector2(9, -7.72f);
    }
}
