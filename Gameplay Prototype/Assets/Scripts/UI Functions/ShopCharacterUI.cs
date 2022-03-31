/**
// File Name :         ShopCharacterUI.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the characters being displayed in the shop
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ShopCharacterUI : MonoBehaviour
{
    public int partyIndex;

    public GameObject shopCardPrefab;
    public GameObject slotPrefab;
    public GameObject buttonPrefab;

    public GameObject txtPrefab;
    public Character character;

    GameObject button;

    public Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        if (Party.party.Length > partyIndex)
        {
            character = Party.party[partyIndex];
            GetComponentInChildren<CustomCharacterDisplay>().character = character;

            var s = -1;
            foreach (string c in character.deck)
            {
                s++;

                var sl = Instantiate(slotPrefab, GameObject.Find("Canvas").transform);
                var ui1 = sl.GetComponent<SlotUIBehaviour>();
                sl.transform.SetAsFirstSibling();
                ui1.slot = s;
                ui1.character = this;

                var card = (Card)Activator.CreateInstance(Type.GetType(c));
                var o = Instantiate(shopCardPrefab, GameObject.Find("Canvas").transform);

                var ui = o.GetComponent<UpdateCardUI>();
                ui.card = card;
                ui.slot = s;
                ui.character = this;
            }

            var t = Instantiate(txtPrefab, GameObject.Find("Canvas").transform);
            t.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y - 1));
            

            nameText = t.GetComponent<Text>();
            nameText.text = character.cName;

            if (!SceneManager.GetActiveScene().name.Equals("Prep") || partyIndex != 0)
            {
                var b = Instantiate(buttonPrefab, GameObject.Find("Canvas").transform);
                b.GetComponent<Button>().onClick.AddListener(RemoveAll);
                b.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x - 1.4f, transform.position.y + 3.75f));
                button = b;
            }


            
        }
        else
        {
            GetComponentInChildren<CustomCharacterDisplay>().gameObject.SetActive(false);
        }

    }

    void Update()
    {
        if (Party.party.Length == 1 && button != null)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    void RemoveAll()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = null;
        Destroy(button);
        button = null;
        
        foreach(SlotUIBehaviour s in FindObjectsOfType<SlotUIBehaviour>())
        {
            if (s.character == this)
            {
                Destroy(s.gameObject);
            }
        }

        foreach (UpdateCardUI s in FindObjectsOfType<UpdateCardUI>())
        {
            if (s.character == this)
            {
                Destroy(s.gameObject);
            }
        }

        nameText.text = "[Removed]";

        var newParty = new Character[Party.party.Length - 1];

        var i = 0;
        foreach (Character c in Party.party)
        {
            if (c != character)
            {
                newParty[i] = c;
                i++;
            }
        }

        Party.party = newParty;
    }
}
