/**
// File Name :         ActionUI.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Handles UI that allows for replacing cards in decks when a new one is bought from the shop
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewCardUI : MonoBehaviour
{
    public Card card;
    public GameObject cardui;
    public GameObject characteruiPrefab;
    public GameObject buttonPrefab;
    GameObject characterui;
    public GameObject b1;
    public GameObject b2;
    List<Character> typeParty = new List<Character>();
    int selected = 0;
    Vector2 cuipos;
    public GameObject replaceButton;
    GameObject sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<ShopManager>().gameObject;
        sm.SetActive(false);

        cuipos = FindObjectOfType<ShopCharCard>().transform.position;
        Destroy(FindObjectOfType<ShopCharCard>().gameObject);

        if (card == null)
        {
            card = new Defend();
        }

        cardui.GetComponent<CardUI>().card = card;

        var a = 0;
        foreach(Character c in Party.party)
        {
            if (card.cardType() == c.types[0] || card.cardType() == c.types[1] || card.cardType() == Card.CardTypes.None)
            {
                a++;
                typeParty.Add(c);
            }
            else
            {
                typeParty.Add(null);
            }
        }


        NextChar();

        replaceButton.GetComponent<Button>().onClick.AddListener(ReplaceCard);

        if (a != 1)
        {
            b1.GetComponent<Button>().onClick.AddListener(NextChar);
            b2.GetComponent<Button>().onClick.AddListener(LastChar);
        }
        else
        {
            Destroy(b1);
            Destroy(b2);
        }
    }

    void NextChar()
    {
        do
        {
            selected++;
            if (selected == typeParty.Count)
            {
                selected = 0;
            }
        }
        while (typeParty[selected] == null);


        RefreshCharacter();
        characterui.GetComponent<ShopCharCard>().character = typeParty[selected];
    }

    void ReplaceCard()
    {
        Party.party[selected].deck[characterui.GetComponent<ShopCharCard>().currentSlot] = card.cardClass();
        sm.gameObject.SetActive(true);
        FindObjectOfType<ShopManager>().Invoke("SwitchToShop", 0.1f);

        Destroy(gameObject);
    }

    void LastChar()
    {
        do
        {
            selected--;
            if (selected == -1)
            {
                selected = typeParty.Count-1;
            }
        }
        while (typeParty[selected] == null);

        RefreshCharacter();
        characterui.GetComponent<ShopCharCard>().character = typeParty[selected];
    }

    void RefreshCharacter()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("ShopUI"))
        {
            Destroy(o);
        }

        if (characterui != null)
        {
            Destroy(characterui);
        }
        characterui = Instantiate(characteruiPrefab, cuipos, Quaternion.identity);
        characterui.transform.SetParent(transform.GetChild(0),false);
        characterui.GetComponent<RectTransform>().position = cuipos;


    }

    public static void SetParentAndReset(RectTransform rect, Transform parent)
    {
        rect.SetParent(parent);
        rect.localScale = Vector3.one;
        rect.localPosition = Vector3.zero;
    }
}
