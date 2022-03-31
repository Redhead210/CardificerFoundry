/**
// File Name :         Deck.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : The basis of the deck system
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck : MonoBehaviour
{
    public static Sprite platformSprite;
    public static Sprite platformSpriteO;
    public static Sprite platformSpriteS;

    public static List<Card> deck = new List<Card>();
    public static List<Card> hand = new List<Card>();
    public static List<Card> discard = new List<Card>();
    public static List<Card> test = new List<Card>();

    public GameObject cardPrefab;
    public GameObject platformPrefab;

    public GameObject platformPrefab2;
    public GameObject platformPrefab3;

    public Sprite ptSprite;
    public Sprite ptSpriteO;
    public Sprite ptSpriteS;

    public Sprite ptSprite2;
    public Sprite ptSpriteO2;
    public Sprite ptSpriteS2;

    public Sprite ptSprite3;
    public Sprite ptSpriteO3;
    public Sprite ptSpriteS3;

    public static System.Random rng = new System.Random();

    void Awake()
    {
        if(GameManager.act == 1)
        {
            platformSprite = ptSprite2;
            platformSpriteO = ptSpriteO2;
            platformSpriteS = ptSpriteS2;
        }
        else if(GameManager.act == 2 || GameManager.act == 3)
        {
            platformSprite = ptSprite3;
            platformSpriteO = ptSpriteO3;
            platformSpriteS = ptSpriteS3;
        }
        else
        {
            platformSprite = ptSprite;
            platformSpriteO = ptSpriteO;
            platformSpriteS = ptSpriteS;
        }

        RefreshDeck();
    }

    void Update()
    {

        if (FindObjectsOfType<DisplayCard>().Length == 0)
        {
            for(int i = 0; i < 5; i++)
            {
                drawCard();
            }
        }
    }

    public static void RefreshDeck()
    {
        DeleteAll();
        deck.Clear();
        discard.Clear();
        hand.Clear();

        foreach (Character pm in Party.party)
        {
            if (pm.hp > 0)
            {
                var sl = 0;
                foreach (string s in pm.deck)
                {
                    var r = 1;
                    if (pm.level / GameManager.levelsToGold > sl)
                    {
                        r = 3;
                    }
                    else if (pm.level > sl)
                    {
                        r = 2;
                    }

                    var addCard = (Card)Activator.CreateInstance(Type.GetType(s));
                    addCard.rank = r;

                    deck.Add(addCard);
                    sl++;
                }
            }
        }

        Shuffle(deck);
    }

    public static void DiscardAll()
    {
        foreach(DisplayCard c in FindObjectsOfType<DisplayCard>())
        {
            c.DiscardThis();
        }
    }

    public static void DeleteAll()
    {
        DisplayCard.activeCards = 0;

        foreach (DisplayCard c in FindObjectsOfType<DisplayCard>())
        {
            Destroy(c.gameObject);
        }
    }

    public void drawCard()
    {
        if (deck.Count > 0)
        {
            var c = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            c.GetComponent<DisplayCard>().thiscard = deck[0];
            c.transform.SetParent(FindObjectOfType<Canvas>().transform);

            deck.RemoveAt(0);
        }
        else if (discard.Count > 0)
        {
            deck = new List<Card>(discard);
            discard.Clear();

            Shuffle(deck);

            drawCard();
        }
    }

    public static void Shuffle<T>(List<T> l)
    {
        if(GameManager.act != -1)
        {
            for (int i = l.Count - 1; i > 0; i--)
            {
                int rng = UnityEngine.Random.Range(0, i);
                T ph = l[i];
                l[i] = l[rng];
                l[rng] = ph;
            }
        }
       // print("bruh");
    }
}
