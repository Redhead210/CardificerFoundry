/**
// File Name :         CardDictionary.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Creates arrays of all cards based on types used for shop
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class CardDictionary : MonoBehaviour
{
    public static List<string>[] allCards = new List<string>[(int)Card.CardTypes.None+1];
    public bool setup = false;

    void Awake()
    {
        if (!setup)
        {
            setup = true;
            for (int i = 0; i < allCards.Length; i++)
            {
                allCards[i] = new List<string>();
            }

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type t in types)
            {
                if (t.BaseType == typeof(Card))
                {
                    var c = (Card)Activator.CreateInstance(t);
                    allCards[(int)c.cardType()].Add(c.cardClass());
                }
            }
        }
    }

    public static string getRandomCard(Card.CardTypes type)
    {
        var range = allCards[(int)type].Count;
        var s = allCards[(int)type][UnityEngine.Random.Range(0, range)];
        
        return s;
    }

    public static string getRandomCard(Card.CardTypes type, bool FilterSynergy)
    {
        var range = allCards[(int)type].Count;
        var s = allCards[(int)type][UnityEngine.Random.Range(0, range)];
        if (FilterSynergy && Card.stringToCard(s).SynergyCard())
        {
            return getRandomCard(type, true);
        }

        return s;
    }

    public static Card getRandomCardAsCard(Card.CardTypes type)
    {
        var c = getRandomCard(type);
        var t = Type.GetType(getRandomCard(type));

        if (t == null)
        {
            return getRandomCardAsCard(type);
        }
        
        return (Card)Activator.CreateInstance(t);
    }

    public static Card getRandomCardAsCard(Card.CardTypes type, bool FilterSynergy)
    {
        var c = getRandomCard(type);
        var t = Type.GetType(getRandomCard(type,FilterSynergy));
        var r = (Card)Activator.CreateInstance(t);
        return r;
    }
}
