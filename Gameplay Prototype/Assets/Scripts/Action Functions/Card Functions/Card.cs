/**
// File Name :         Card.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : The basis for all cards
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Card
{
    public string effect;
    public int rank = 1;
    Sprite art;

    public CharacterBehaviour caster;
    public CharacterBehaviour target;

    public enum CardTypes { Melee, Ranged, Fire, Ice, Shadow, Light, Nature, Tech, None };
    public enum Targets { None, Enemy, Players, Both};

    public Card (int rank = 1)
    {
        this.rank = rank;
    }

    public virtual string Bound()
    {
        return null;
    }

    public virtual bool SynergyCard()
    {
        return false;
    }

    /// <summary>
    /// Card's name in UI
    /// </summary>
    /// <returns></returns>
    public abstract string cardName();

    /// <summary>
    /// Card's description in UI
    /// </summary>
    /// <returns></returns>
    public abstract string cardDesc();

    /// <summary>
    /// The Card's type
    /// </summary>
    /// <returns></returns>
    public abstract CardTypes cardType();

    /// <summary>
    /// The speed that the card activates in battle queue
    /// </summary>
    /// <returns></returns>
    public abstract int cardSpeed();

    /// <summary>
    /// The card's border color
    /// </summary>
    /// <returns></returns>
    public virtual Color cardColor()
    {
        switch(cardType())
        {
            case CardTypes.Melee:
                return new Color32(128, 103, 82, 255);
            case CardTypes.Nature:
                return new Color(0f, 0.4f, 0f);
            case CardTypes.Ice:
                return new Color(0, 0.3f, 0.6f);
            case CardTypes.Fire:
                return new Color(0.6f, 0, 0);
            case CardTypes.Light:
                return new Color32(255, 236, 115, 255);
            case CardTypes.Shadow:
                return new Color(0.6f, 0f, 0.6f);
            case CardTypes.Ranged:
                return new Color32(102, 71, 42, 255);
            case CardTypes.Tech:
                return new Color32(236, 141, 70, 255);
            default:
                return Color.gray;
        }
    }

    public abstract void castCard(CharacterBehaviour cb = null);

    /// <summary>
    /// What types of targets the card can target, if any
    /// </summary>
    /// <returns></returns>
    public virtual Targets cardTarget()
    {
        return Targets.None;
    }

    /// <summary>
    /// Returns the name of the implemented child class. Make sure this is exact or it fucks everything up.
    /// </summary>
    /// <returns></returns>
    public abstract string cardClass();

    public Card()
    {
        var spriteList = Resources.LoadAll("Card Art",typeof(Sprite));
        foreach (Sprite s in spriteList)
        {
            if (s.name.Equals(cardName()))
            {
                art = s;
                break;
            }
        }

        Deck.hand.Add(this);
    }

    public virtual string FlavorText()
    {
        return "Insert Flavor Text Here.";
    }


    public Sprite cardArt()
    {
        return art;
    }

    /// <summary>
    /// Returns a CardType enum as a string
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static string TypeToString(CardTypes t)
    {
        switch (t)
        {
            case CardTypes.Fire:
                return "Fire";

            case CardTypes.Ice:
                return "Ice";

            case CardTypes.Light:
                return "Light";

            case CardTypes.Melee:
                return "Melee";

            case CardTypes.Nature:
                return "Nature";

            case CardTypes.Ranged:
                return "Ranged";

            case CardTypes.Shadow:
                return "Shadow";

            case CardTypes.Tech:
                return "Tech";

            case CardTypes.None:
                return "Neutral";
        }

        return "None";
    }

    public static Card stringToCard(string name)
    {
        var t = Type.GetType(name);
        if (t == null)
        {
            return new StackOverflow();
        }

        return (Card)Activator.CreateInstance(t);
    }

    public static Card stringToCard(string name, int rank)
    {
        var t = Type.GetType(name);
        var r = (Card)Activator.CreateInstance(t);
        r.rank = rank;
        return r;
    }
}
