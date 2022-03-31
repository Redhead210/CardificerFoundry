/**
// File Name :         Character.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Stores all character data
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Character")]
public class Character : ScriptableObject
{
    public int hp;
    public int maxhp;
    public int hpmod;

    public Sprite sprite;
    public string cName;

    public Card.CardTypes[] types = new Card.CardTypes[2];
    public string[] deck;
    public int level;

    public Sprite hat;
    public Sprite body;

    public int xp = 0;
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_maxhp">HP</param>
    /// <param name="_sprite">Sprite</param>
    /// <param name="_name">Name</param>
    /// <param name="_types">Types</param>
    /// <param name="_deck">Deck</param>
    public Character(int _maxhp, string _name, Card.CardTypes[] _types, string[] _deck, int _level = 1, Sprite _sprite = null)
    {
        hp = _maxhp;
        maxhp = hp;
        sprite = _sprite;
        if (sprite == null)
        {
            sprite = GameManager.gm.genericCharacter;
        }
        cName = _name;
        types = _types;
        deck = _deck;
        level = _level;
        hpmod = HPValue(_types[0]) + HPValue(_types[1]);
    }

    public Character(Character c)
    {
        hp = c.hp;
        maxhp = hp;
        sprite = c.sprite;
        hat = c.hat;
        body = c.body;
        cName = c.cName;
        types = c.types;
        level = c.level;
        hpmod = c.hpmod;
        deck = c.deck;
    }

    public Character Clone()
    {
        var c = new Character(hp, cName, types, deck, level, sprite);
        c.hat = hat;
        c.body = body;
        return c;
    }

    static int HPValue(Card.CardTypes t)
    {
        switch (t)
        {
            case Card.CardTypes.Fire:
                return 2;
            case Card.CardTypes.Ice:
                return 3;
            case Card.CardTypes.Light:
                return 4;
            case Card.CardTypes.Melee:
                return 4;
            case Card.CardTypes.Nature:
                return 3;
            case Card.CardTypes.Shadow:
                return 1;
            case Card.CardTypes.Ranged:
                return 2;
            default:
                return 2;
        }
    }

    public bool IsType(Card.CardTypes t)
    {
        return types[0] == t || types[1] == t;
    }

    public static Character CharacterGen(int level, Card.CardTypes t1 = Card.CardTypes.None, Card.CardTypes t2 = Card.CardTypes.None)
    {
        var firstNames = new List<string>[]
        {
            new List<string>()
            {
                //melee names 
                "Ethan", "Harold", "Marcus", "Bruce", "Kane", "Brandon", "Leonidas", "Hector","Achilles"
            },
            new List<string>()
            {
                //ranged names
                "Gunther", "Liam", "Artemis", "Addonis", "Chase", "Gallamax", "Oliver","Jessie", "Anne","Doc"
            },
            new List<string>()
            {
                //fire names
                "Cinder","Phoenix","Blaze","Cyrus","Pyron", "Lucifer", "Pyra","Ash","Hesphestus"
            },
            new List<string>()
            {
                //ice names
                "Noelle","Jack","North","Hale", "Nora", "Grey","Gelal","Simon","Zane"
            },
            new List<string>()
            {
                //shadow names
                "Loki","Donovan","Nox","Zi","Null","Voidius", "Tenebris", "Malum","Malcior"
            },
            new List<string>()
            {
                //Light names
                "Apollo","Uther","Sol","Dawn","Alina","Aurora","Xexus","Ilum","Nimbus"
            },
            new List<string>()
            {
                //Nature Names
                "Jade","Jasper","Raven","Dawn","Birch", "Oak","Cyprus","Willow", "Tara","Gaea"
            },
            new List<string>()
            {
                //Tech Names
                "Doc","Linux","Coda","Veronica","Regis", "Silicon","Coal","Pewter","Ore"
            }
        };

        var lastNames = new List<string>[]
        {
            new List<string>()
            {
                //Melee Names
                "Ironheart", "Stoneforge", "the Fighter", "Bladesteel", "Stronghold", "Scarface", "ScareKnuckle", "Brawlson", "BoneCrusher"
            },
            new List<string>()
            {
                //Ranged names
                "Hawkeye", "Quiver", "the Marksman", "Arrowhead", "Bandolier", "Earp", "Sundance", "Swiftstring", "TrueShot","Justice"
            },
            new List<string>()
            {
                //fire names
                "Ashbringer","Flameward","Pyroclad","Candlewick", "Heatstroke","Magnus", "Cinders", "Ignius","Beelzebub"
            },
            new List<string>()
            {
                //ice names
                "Everwinter","Cyrogen","Permafrost","Icewind","Chillrine","Freezener", "Glacius", "Chill","Coolwalker"
            },
            new List<string>()
            {
                //shadow names
                "the Cursed","the Forsaken","Darkbender","Doomcaller","Hutchings","Of the Night", "Shadowborn","Underfoot","The Thief"
            },
            new List<string>()
            {
                //light names
                "Lightforged","the Paladin","Holymin","Sunrise", "DayWalker", "Brightstar","Prism","Rainbow","Lightbright"
            },
            new List<string>()
            {
                //Nature names
                "Mossgrove","Barkwood","Earthspawn","the Druid", "Of the Forest", "Earthborn", "Grassfed","Wyrmwood","Toadstool"
            },
            new List<string>()
            {
                //Tech names
                "Gearshift","the Mechanic","Degreaser","Cogsmith", "Brassbeard", "Forgeborn","Tech-kin","Smith","Smeltson"
            }
        };

        if (t1 == Card.CardTypes.None)
        {
            t1 = (Card.CardTypes)Random.Range(0, (int)Card.CardTypes.None);
        }

        if (t2 == Card.CardTypes.None || t2 == t1)
        {
            t2 = t1;
            while ((int)t2 == (int)t1)
            {
                t2 = (Card.CardTypes)Random.Range(0, (int)Card.CardTypes.None);
            }
        }


        var types = new Card.CardTypes[] { t1, t2 };

        var hpmd = HPValue(t1) + HPValue(t2);
        var hpmx = 10 + (level * hpmd);

        var deck = new string[8];

        for (int i = 0; i < deck.Length; i++)
        {
            if (i <= level + (Mathf.CeilToInt(level / 2)))
            {
                deck[i] = CardDictionary.getRandomCard(types[i%2],i<2);
            }
            else
            {
                if (i%2==0)
                {
                    deck[i] = "Strike";
                }
                else
                {
                    deck[i] = "Defend";
                }
            }
        }

        var name = firstNames[(int)t1][Random.Range(0, firstNames[(int)t1].Count)] + " " + lastNames[(int)t2][Random.Range(0, lastNames[(int)t2].Count)];

        if (Random.Range(0,450)==0)
        {
            name = "Joe.";
        }

        var r = new Character(hpmx, name, types, deck, level);
        r.hat = GameManager.gm.characterHat[(int)t2];
        r.body = GameManager.gm.characterBody[(int)t1];

        return r;
        
    }
}
