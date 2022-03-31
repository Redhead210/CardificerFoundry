/**
// File Name :         Buy Character.cs
// Author :            Tyler Colander
// Creation Date :     October 2021
//
// Brief Description : Allows for characters to be bought
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacter : MonoBehaviour
{
    public GameObject buyButton;
    Character character;
    int cost;

    // Start is called before the first frame update
    void Start()
    {
        buyButton.GetComponent<Button>().onClick.AddListener(BuyChar);
        character = GetComponentInChildren<ShopCharCard>().character;

        cost = GameManager.characterBaseCost + (character.level * GameManager.characterLevelCost);
        buyButton.GetComponentInChildren<Text>().text = "Buy " + cost + "C";
    }

    void BuyChar()
    {
        if (GameManager.money >= cost)
        {
            if (Party.party.Length == 3)
            {
                var t = FloatingText.Create(buyButton.transform.position, "Party Is Full!", true);
                t.transform.SetAsLastSibling();
            }
            else
            {
                Character[] newParty = new Character[Party.party.Length + 1];

                for (int i = 0; i < Party.party.Length; i++)
                {
                    newParty[i] = Party.party[i];
                }

                GameManager.money -= cost;

                newParty[newParty.Length - 1] = character;

                Party.party = newParty;
                Destroy(gameObject);
            }
        } 
        else
        {
            var noMoney = FloatingText.Create(GetComponentInChildren<Button>().transform.position, ("Not enough cogs"), true);
            noMoney.transform.SetAsLastSibling();
        }   
    }
}
