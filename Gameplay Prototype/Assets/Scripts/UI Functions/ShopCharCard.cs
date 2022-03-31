/**
// File Name :         ShopCharCard.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Shows each card in the characters deck, including the swapping and card slots
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCharCard : MonoBehaviour
{
    public Character character;
    Card card;
    public int currentSlot;
    public int leftSlot;
    public int rightSlot;

    public int cost;
    public Sprite bronzeslot;
    public Sprite silverslot;

    public Sprite bronzeborder;
    public Sprite silverborder;
    public Sprite goldborder;
    public Sprite tempart;
    public static UpdateCardUI held;

    public GameObject buttonPrefab;
    public GameObject characterPrefab;
    public GameObject textPrefab;

    public GameObject leftCardUI;
    public GameObject centerCardUI;
    public GameObject rightCardUI;

    public GameObject buttonLeft;
    public GameObject buttonRight;

    Vector2 leftCardPos;
    Vector2 centerCardPos;
    Vector2 rightCardPos;

    int leftSpeed = 1;
    int rightSpeed = 1;

    public GameObject scrollText;

    void Start()
    {
        if (character == null)
        {
            character = Character.CharacterGen(Random.Range(Party.GetLowestLevel(), Party.GetHighestLevel()+2));
        }

        currentSlot = 0;
        rightSlot = character.deck.Length - 1;
        leftSlot = 1;

        leftCardPos = leftCardUI.transform.position;
        rightCardPos = rightCardUI.transform.position;
        centerCardPos = centerCardUI.transform.position;



        cost = 200 + (int)(Mathf.Pow(character.level, 2) * 5);

        var pos = Camera.main.ScreenToWorldPoint(transform.position);
        var p = Instantiate(characterPrefab, new Vector3(pos.x-9,pos.y-2-0.75f, 0), Quaternion.identity);
        p.transform.SetParent(transform);
        p.GetComponentInChildren<CustomCharacterDisplay>().character = character;

        var t = Instantiate(textPrefab, transform);
        t.transform.position = Camera.main.WorldToScreenPoint(new Vector3(pos.x - 9, pos.y - 3.2f-0.75f, 0));
        t.GetComponent<Text>().text = character.cName;

        var t1 = Instantiate(textPrefab, transform);
        t1.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(new Vector3(pos.x - 9, pos.y - 3.8f-0.75f, 0));
        t1.GetComponent<Text>().text = "Level: " + character.level + " | Health: " + character.maxhp;

        buttonLeft.GetComponent<Button>().onClick.AddListener(PreviousSlot);
        buttonRight.GetComponent<Button>().onClick.AddListener(NextSlot);

    }

    public void NextSlot()
    {
        currentSlot++;
        leftSlot++;
        rightSlot++;

        if (currentSlot == character.deck.Length)
        {
            currentSlot = 0;
        }
        if (leftSlot == character.deck.Length)
        {
            leftSlot = 0;
        }
        if (rightSlot == character.deck.Length)
        {
            rightSlot = 0;
        }

        leftCardUI.transform.position = rightCardPos;
        centerCardUI.transform.position = leftCardPos;
        rightCardUI.transform.position = centerCardPos;

        centerCardUI.transform.localScale = new Vector2(0.75f, 0.75f);
        rightCardUI.transform.localScale = new Vector2(1, 1);
        leftCardUI.transform.localScale = new Vector2(0.75f, 0.75f);

        leftCardUI.transform.SetAsFirstSibling();
        leftSpeed = 6;
        rightSpeed = 1;


    }

    public void PreviousSlot()
    {
        currentSlot--;
        leftSlot--;
        rightSlot--;

        if (currentSlot == -1)
        {
            currentSlot = character.deck.Length - 1;
        }
        if (leftSlot == -1)
        {
            leftSlot = character.deck.Length - 1;
        }
        if (rightSlot == -1)
        {
            rightSlot = character.deck.Length - 1;
        }

        rightCardUI.transform.position = leftCardPos;
        centerCardUI.transform.position = rightCardPos;
        leftCardUI.transform.position = centerCardPos;

        centerCardUI.transform.localScale = new Vector2(0.75f, 0.75f);
        leftCardUI.transform.localScale = new Vector2(1, 1);
        rightCardUI.transform.localScale = new Vector2(0.75f, 0.75f);

        rightCardUI.transform.SetAsFirstSibling();
        rightSpeed = 6;
        leftSpeed = 1;
    }

    void Update()
    {
        scrollText.GetComponent<Text>().text = (currentSlot+1) + "/" + character.deck.Length;
        UpdateCardUI(leftCardUI, Card.stringToCard(character.deck[leftSlot]),leftSlot);
        UpdateCardUI(rightCardUI, Card.stringToCard(character.deck[rightSlot]),rightSlot);
        UpdateCardUI(centerCardUI, Card.stringToCard(character.deck[currentSlot]),currentSlot);

        var speed = 1000f;
        centerCardUI.transform.position = Vector2.MoveTowards(centerCardUI.transform.position, centerCardPos, speed * Time.deltaTime);
        leftCardUI.transform.position = Vector2.MoveTowards(leftCardUI.transform.position, leftCardPos, speed * Time.deltaTime);
        rightCardUI.transform.position = Vector2.MoveTowards(rightCardUI.transform.position, rightCardPos, speed * Time.deltaTime);

        speed = 2.5f;
        if (centerCardUI.transform.localScale.x != 1)
        {
            centerCardUI.transform.localScale = Vector2.MoveTowards(centerCardUI.transform.localScale, new Vector2(1, 1), speed * Time.deltaTime);
        }

        if (leftCardUI.transform.localScale.x != 0.75f)
        {
            leftCardUI.transform.localScale = Vector2.MoveTowards(leftCardUI.transform.localScale, new Vector2(0.75f, 0.75f), speed * Time.deltaTime*leftSpeed);
        }

        if (rightCardUI.transform.localScale.x != 0.75f)
        {
            rightCardUI.transform.localScale = Vector2.MoveTowards(rightCardUI.transform.localScale, new Vector2(0.75f, 0.75f), speed * Time.deltaTime*rightSpeed);
        }
    }

    void UpdateCardUI(GameObject obj, Card card,  int currentSlot)
    {
        if (character.level/GameManager.levelsToGold > currentSlot)
        {
            card.rank = 3;
        }
        else if (character.level % 10 > currentSlot || character.level >= 10)
        {
            card.rank = 2;
        }
        else
        {
            card.rank = 1;
        }

        Text[] textElements = obj.GetComponentsInChildren<Text>();

        textElements[0].text = card.cardName();
        textElements[1].text = "" + card.cardSpeed();
        textElements[2].text = card.cardDesc();
        textElements[3].text = Card.TypeToString(card.cardType());

        Image[] imageElements = obj.GetComponentsInChildren<Image>();
        if (card.cardArt() != null)
        {
            imageElements[0].sprite = card.cardArt();
        }
        else
        {
            imageElements[0].sprite = tempart;
        }
        imageElements[1].color = card.cardColor();

        if (card.rank == 3)
        {
            imageElements[2].sprite = goldborder;
            textElements[0].color = Color.white;
        }
        else if (card.rank == 2)
        {
            imageElements[2].sprite = silverborder;
            textElements[0].color = Color.white;
        }
        else
        {
            imageElements[2].sprite = bronzeborder;
            textElements[0].color = new Color32(209, 209, 209, 255);
        }
    }
}
