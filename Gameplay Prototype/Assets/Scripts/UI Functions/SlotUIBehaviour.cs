/**
// File Name :         SlotUIBehaviour.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the slots and the manipulation of cards within them
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUIBehaviour : MonoBehaviour
{
    public int slot;
    public ShopCharacterUI character;
    public Sprite silverSlot;
    public Sprite goldSlot;
    public bool hover = false;

    void Start()
    {
        if ((int)character.character.level / GameManager.levelsToGold > slot)
        {
            GetComponent<Image>().sprite = goldSlot;
        }
        else if (character.character.level % 10 > slot || character.character.level >= 10)
        {
            GetComponent<Image>().sprite = silverSlot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var p = character.transform.position;
        transform.position = Camera.main.WorldToScreenPoint(new Vector3(p.x + (slot * 3.5f) + 5, p.y + 1.75f));

        hover = IsWithinSlot(Input.mousePosition);
    }

    public bool IsWithinSlot(Vector2 p)
    {
        var img = GetComponent<Image>();
        var w = img.sprite.rect.width;
        var h = img.sprite.rect.height;

        var p1 = new Vector2(transform.position.x + w, transform.position.y + h);
        var p2 = new Vector2(transform.position.x - w, transform.position.y - h);

        return p.x <= p1.x && p.x >= p2.x && p.y <= p1.y && p.y >= p2.y;
    }
}
