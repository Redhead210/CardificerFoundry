/**
// File Name :         UpdateCardUI.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Updates the cards look based on the tile slots
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UpdateCardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Card card;
    bool hover = false;
    public int slot = 0;
    public ShopCharacterUI character;
    Vector2 moveTo;

    public Sprite bronzeborder;
    public Sprite silverborder;
    public Sprite goldborder;
    public static UpdateCardUI held;

    public GameObject inspectorPrefab;

    public void Start()
    {
        transform.localScale = new Vector2(0.5f, 0.5f);
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);
        var p = character.transform.position;
        transform.position = Camera.main.WorldToScreenPoint(new Vector2(p.x,p.y+2));
    }

    // Update is called once per frame
    void Update()
    {
        if (held == null)
        {
            var p = character.transform.position;
            moveTo = Camera.main.WorldToScreenPoint(new Vector2(p.x + (slot * 3.5f) + 5, p.y + 1.75f));

            transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * 5000);
        }

        if (held == this)
        {
            transform.position = Input.mousePosition;
        }

        if (card != null)
        {
            Text[] textElements = GetComponentsInChildren<Text>();

            textElements[0].text = card.cardName();
            textElements[1].text = "" + card.cardSpeed();
            textElements[2].text = card.cardDesc();
            if (card.Bound() != null)
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
            imageElements[1].color = card.cardColor();

            if (character.character.level/GameManager.levelsToGold > slot)
            {
                card.rank = 3;
            }
            else if (character.character.level % 10 > slot || character.character.level >= 10)
            {
                card.rank = 2;
            }
            else
            {
                card.rank = 1;
            }

            if  (card.rank == 3) {
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

        if (hover && held == null && Vector2.Distance(transform.position, moveTo) < 0.001f)
        {
            transform.SetAsLastSibling();
            if (transform.localScale.x < 0.75)
            {
                var i = transform.localScale.x + (5 * Time.deltaTime);
                i = Mathf.Min(i, 0.75f);
                transform.localScale = new Vector3(i, i, -1);
            }
        }
        else
        {
            if (transform.localScale.x > 0.5)
            {
                var i = transform.localScale.x - (5 * Time.deltaTime);
                i = Mathf.Max(i, 0.5f);
                transform.localScale = new Vector3(i, i, -1);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        held = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        held = null;

        SlotUIBehaviour dragged = null;
        foreach (SlotUIBehaviour s in FindObjectsOfType<SlotUIBehaviour>())
        {
            if (s.hover == true && (s.character != character || s.slot != slot))
            {
                dragged = s;
                break;
            }
        }

        if (dragged != null)
        {
            UpdateCardUI ncard = null;
            foreach (UpdateCardUI c in FindObjectsOfType<UpdateCardUI>())
            {
                if (c.slot == dragged.slot && c.character == dragged.character)
                {
                    ncard = c;
                    break;
                }
            }

            if (CanBeSwapped(ncard))
            {
                var ph = slot;
                slot = ncard.slot;
                ncard.slot = ph;

                var ph1 = character;
                character = ncard.character;
                ncard.character = ph1;

                ncard.character.character.deck[ncard.slot] = ncard.card.cardClass();
                character.character.deck[slot] = card.cardClass();

                ncard.transform.SetAsLastSibling();
                transform.SetAsLastSibling();
            }
            else
            {
                var o = FloatingText.Create(Input.mousePosition, "Can't swap!",true);
                o.GetComponent<Outline>().effectColor = Color.black;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public bool CanBeSwapped(UpdateCardUI o)
    {
        if (!o.character.Equals(character) && SceneManager.GetActiveScene().name.Equals("Prep"))
        {
            return false;
        }

        bool CompatibleTypes(UpdateCardUI o1, UpdateCardUI o2)
        {
            return o1.character.character.IsType(o2.card.cardType()) || o2.card.cardType() == Card.CardTypes.None;
        }

        return CompatibleTypes(o, this) && CompatibleTypes(this, o);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponentInParent<CardInspectorUI>() == null && eventData.button == PointerEventData.InputButton.Right && held == null)
        {
           


            var i = Instantiate(inspectorPrefab);
            i.GetComponent<CardInspectorUI>().cname = card.cardClass();
            i.GetComponent<CardInspectorUI>().rank = card.rank;
        }
    }
}
