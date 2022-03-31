/**
// File Name :         CardUI.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Displays cards in the shop and prep screens
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerClickHandler
{
    public Sprite tempart;
    public Sprite bronzeborder;
    public Sprite silverborder;
    public Sprite goldborder;
    public Card card;
    public GameObject inspectorPrefab;

    // Update is called once per frame
    void Update()
    {
        UpdateCardUI(card);
    }

    void UpdateCardUI(Card card)
    {
        Text[] textElements = GetComponentsInChildren<Text>();

        textElements[0].text = card.cardName();
        textElements[1].text = "" + card.cardSpeed();
        textElements[2].text = card.cardDesc();
        if (card.Bound()!=null)
        {
            textElements[3].text = card.Bound();
        }
        else
        {
            textElements[3].text = Card.TypeToString(card.cardType());
        }
        

        Image[] imageElements = GetComponentsInChildren<Image>();
        if (card.cardArt() != null)
        {
            imageElements[0].sprite = card.cardArt();
        }
        else
        {
            imageElements[0].sprite = tempart;
        }
        imageElements[1].color = card.cardColor();

        if (card.rank == 2)
        {
            imageElements[2].sprite = silverborder;
            textElements[0].color = Color.white;
        }
        else if (card.rank == 3)
        {
            imageElements[2].sprite = goldborder;
            textElements[0].color = Color.white;
        }
        else
        {
            imageElements[2].sprite = bronzeborder;
            textElements[0].color = new Color32(209, 209, 209, 255);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponentInParent<CardInspectorUI>() == null && eventData.button == PointerEventData.InputButton.Right)
        {
            var i = Instantiate(inspectorPrefab);
            i.GetComponent<CardInspectorUI>().cname = card.cardClass();
            i.GetComponent<CardInspectorUI>().rank = card.rank;
        }
    }
}
