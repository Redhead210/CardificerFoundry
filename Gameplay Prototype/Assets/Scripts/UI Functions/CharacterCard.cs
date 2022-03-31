/**
// File Name :         CharacterCard.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Displays characters decks within the shop and the prep screen
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterCard : MonoBehaviour, IPointerClickHandler
{
    public GameObject inspectorPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponentInParent<CardInspectorUI>() == null && eventData.button == PointerEventData.InputButton.Right)
        {
            var p = GetComponentInParent<ShopCharCard>();
            Card card;
            if (p.leftCardUI == gameObject)
            {
                card = Card.stringToCard(p.character.deck[p.leftSlot]);
            }
            else if (p.rightCardUI == gameObject)
            {
                card = Card.stringToCard(p.character.deck[p.rightSlot]);
            }
            else
            {
                card = Card.stringToCard(p.character.deck[p.currentSlot]);
            }

            var i = Instantiate(inspectorPrefab);
            i.GetComponent<CardInspectorUI>().cname = card.cardClass();
            i.GetComponent<CardInspectorUI>().rank = card.rank;
        }
    }
}
