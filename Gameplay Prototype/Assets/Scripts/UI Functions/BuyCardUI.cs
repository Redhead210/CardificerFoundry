/**
// File Name :         BuyCardUI.cs
// Author :            Jason Czech, Tyler Colander
// Creation Date :     October 2021
//
// Brief Description : Allows for cards to be bought
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCardUI : MonoBehaviour
{
    Card card;
    public GameObject buyCardPrefab;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        var type = (Card.CardTypes)Random.Range(0, 7);
        card = CardDictionary.getRandomCardAsCard(type);

        transform.GetChild(0).GetComponent<CardUI>().card = card;

        GetComponentInChildren<Button>().onClick.AddListener(BuyCard);
    }

    void Perish()
    {
        Destroy(gameObject);
    }

    void BuyCard()
    {
        if(GameManager.money >= 50)
        {
            var c = false;
            foreach (Character ch in Party.party)
            {
                if (ch.IsType(card.cardType()))
                {
                    c = true;
                    break;
                }
            }

            if (c)
            {
                var o = Instantiate(buyCardPrefab);
                o.GetComponent<AddNewCardUI>().card = card;

                Invoke("Perish", 0.1f);
                GameManager.money -= 50;
                transform.parent.parent.gameObject.SetActive(false);


            }
            else
            {
                var t = FloatingText.Create(GetComponentInChildren<Button>().transform.position, ("You have no " + card.cardType() + " members!"));
            }

        }
        else
        {
            var noMoney = FloatingText.Create(GetComponentInChildren<Button>().transform.position, ("Not enough cogs"));
            noMoney.transform.SetAsLastSibling();
        }
    }
}
