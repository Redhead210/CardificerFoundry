/**
// File Name :         DisplayCard.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Shows the cards in battle
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour , IDragHandler , IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Card thiscard;
    RectTransform rt;
    Outline ot;
    CanvasGroup cg;

    public Sprite silverborder;
    public Sprite goldborder;

    bool canPlay = true;
    public int cardIndex = 0;
    public float cardPos = 0;
    public static int activeCards = 0;

    public static float animSpeed = 7;
    public static float returnSpeed = 4000;
    public static float hoverSpeed = 5;

    public static int cardSpacing = 350;
    public static int activateY = 400;

    bool onDestroy = false;

    public static int isHeld = -1;
    bool hover = false;

    public GameObject inspectorPrefab;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        ot = GetComponentInChildren<Outline>();
        cg = GetComponent<CanvasGroup>();

        cardIndex = activeCards;
        activeCards++;

        Text[] textElements = GetComponentsInChildren<Text>();

        textElements[0].text = thiscard.cardName();
        textElements[1].text = "" + thiscard.cardSpeed();
        textElements[2].text = thiscard.cardDesc();
        if (thiscard.Bound() == null)
        {
            textElements[3].text = Card.TypeToString(thiscard.cardType());
        }
        else
        {
            textElements[3].text = thiscard.Bound();
        }

        Image[] imageElements = GetComponentsInChildren<Image>();
        if (thiscard.cardArt() != null)
        {
            imageElements[0].sprite = thiscard.cardArt();
        }
        imageElements[1].color = thiscard.cardColor();

        if (thiscard.rank == 2)
        {
            textElements[0].color = Color.white;
            imageElements[2].sprite = silverborder;
        }
        else if (thiscard.rank == 3)
        {
            imageElements[2].sprite = goldborder;
            textElements[0].color = Color.white;
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

    // Start is called before the first frame update
    void Update()
    {
        Text[] textElements = GetComponentsInChildren<Text>();
        textElements[2].text = thiscard.cardDesc();

        activateY = (int)(Screen.height * 0.37f);

        canPlay = canPlayType(thiscard.cardType());
            
        if (canPlay) {
            


            //Calculates an index centering around the middle card (- to the left + to the right)
            cardPos = (activeCards / 2f) - cardIndex;

            ot.enabled = (isHeld == cardIndex);

            //If you're dragging this card
            if (isHeld == cardIndex)
            {
                //Creates a white outline if it's under the activateY
                if (transform.position.y <= activateY)
                {
                    ot.effectColor = Color.white;
                }
                else
                {
                    //If it has no target, outline green
                    if (thiscard.cardTarget() == Card.Targets.None)
                    {
                        ot.effectColor = Color.green;
                    }
                    //If not, remove outline to look better transparent
                    else
                    {
                        ot.enabled = false;
                    }
                }
            }
            //If not being dragged, return to it's normal position
            else
            {
                rt.localPosition = Vector2.MoveTowards(rt.localPosition, new Vector2((((activeCards / 2) - cardIndex) * cardSpacing) / 2, -504), Time.deltaTime * returnSpeed);
            }

            //If the card has a target, and is being dragged above outline, begin making it transparent
            
            if (thiscard.cardTarget() != Card.Targets.None && isHeld == cardIndex && transform.position.y > activateY)
            {
                cg.alpha -= animSpeed * Time.deltaTime;
            }
            //Else, make it opaque
            else
            {
                cg.alpha += animSpeed * Time.deltaTime;
            }
            

            //Makes sure the alpha doesn't drop below 25%
            cg.alpha = Mathf.Clamp(cg.alpha, 0.25f, 1);
        }
        else
        {
            rt.localPosition = Vector2.MoveTowards(rt.localPosition, new Vector2((((activeCards / 2) - cardIndex) * cardSpacing) / 2, -579/*-(Mathf.Abs(cardPos)*20)+((activeCards/2)*20)*/), Time.deltaTime * returnSpeed);
            cg.alpha = 0.4f;
            ot.enabled = false;
        }


        //When onDestroy is activated, shrink until it disappears
        if (onDestroy)
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(0, 0), animSpeed * Time.deltaTime);
            if (transform.localScale.x == 0)
            {
                Destroy(gameObject);
            }
        }

        //Set it's index based on it's index in the hand.
        transform.SetSiblingIndex(cardIndex);
        
        
    }

    void LateUpdate()
    {
        //Grow the UI element when you're hovering over it but not holding it
        if (hover && isHeld != cardIndex && canPlay)
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(1f, 1f), hoverSpeed * Time.deltaTime);
        }
        //Shrink the UI element to nornaml size if you aren't
        else if (!onDestroy)
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(0.75f, 0.75f), hoverSpeed * Time.deltaTime);
        }

        //Set it's index to the top if you're holding or hovering over it
        if ((hover && isHeld == -1 || isHeld == cardIndex) && canPlay)
        {
            transform.SetAsLastSibling();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!BattleTutorial.inDialogue)
        {
            //If you're not destroying it, change the pivot point and set it to the dragged card on drag
            if (!onDestroy && canPlay)
            {
                rt.pivot = new Vector2(0.5f, 0.5f);
                isHeld = cardIndex;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!BattleTutorial.inDialogue)
        {
            if (GetComponentInParent<CardInspectorUI>() == null && eventData.button == PointerEventData.InputButton.Right && isHeld == -1)
            {
                var i = Instantiate(inspectorPrefab);
                i.GetComponent<CardInspectorUI>().cname = thiscard.cardClass();
                i.GetComponent<CardInspectorUI>().rank = thiscard.rank;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!BattleTutorial.inDialogue)
        {
            //Obligatory "not being destroyed" check
            if (!onDestroy && canPlay)
            {
                //Set the position to the mouse position
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //Make the outline green or white based on the y vs the activateY
                if (transform.position.y <= activateY)
                {
                    ot.effectColor = Color.white;
                }
                else
                {
                    ot.effectColor = Color.green;
                }

                //Code for target-based cards
                if (thiscard.cardTarget() != Card.Targets.None)
                {
                    //Get an array of the valid targets
                    var a = new CharacterBehaviour[0];
                    if (thiscard.cardTarget() == Card.Targets.Players)
                    {
                        a = CharacterBehaviour.getAllPlayers();
                    }
                    else if (thiscard.cardTarget() == Card.Targets.Enemy)
                    {
                        a = CharacterBehaviour.getAllEnemies();
                    }
                    else
                    {
                        a = FindObjectsOfType<CharacterBehaviour>();
                    }

                    //If you're under the activateY, make all the platforms normal
                    if (transform.position.y <= activateY)
                    {
                        foreach (CharacterBehaviour c in a)
                        {
                            c.ptColor = 0;
                        }
                    }
                    //If you're over it, draw an outline around targetable platforms
                    else
                    {
                        foreach (CharacterBehaviour c in a)
                        {
                            //Check the distance to each platform, and if the card is close enough outline it green
                            c.ot.enabled = true;
                            if (c.MouseInHitbox())
                            {
                                c.ptColor = 2;
                            }
                            else
                            {
                                c.ptColor = 1;
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!BattleTutorial.inDialogue)
        {
            //Obligatory "not being destroyed" check
            if (!onDestroy)
            {
                isHeld = -1;

                //Bool to cancel a targeted card in case a target isn't selected
                var cancelCast = true;

                //Code for targetable cards
                if (thiscard.cardTarget() != Card.Targets.None)
                {
                    //Get an array of the valid targets
                    var a = new CharacterBehaviour[0];
                    if (thiscard.cardTarget() == Card.Targets.Players)
                    {
                        a = CharacterBehaviour.getAllPlayers();
                    }
                    else if (thiscard.cardTarget() == Card.Targets.Enemy)
                    {
                        a = CharacterBehaviour.getAllEnemies();
                    }
                    else
                    {
                        a = FindObjectsOfType<CharacterBehaviour>();
                    }

                    var activated = false;
                    //Loop through the platforms and find a platform that the card is being dragged to
                    foreach (CharacterBehaviour c in a)
                    {
                        //Resets all platform sprites
                        c.ptColor = 0;

                        //If the card is dragged close enough to the platform, then add it to the battle queue and don't cancel it
                        if (c.MouseInHitbox() && !activated)
                        {
                            BattleManager.queue.Add(new AttackData(thiscard, BattleManager.selectedCharacter, c));
                            activated = true;
                        }
                    }

                    cancelCast = activated;
                }

                //If a card is above the activateY and didn't get cancelled
                if (transform.position.y > activateY && cancelCast)
                {
                    //Add non-target cards to the battle queue
                    if (thiscard.cardTarget() == Card.Targets.None)
                    {
                        BattleManager.queue.Add(new AttackData(thiscard, BattleManager.selectedCharacter));
                    }

                    BattleManager.queue.Sort();

                    var o = Instantiate(GameManager.gm.actPrefab, FindObjectOfType<Canvas>().transform, false);
                    var cst = BattleManager.selectedCharacter;
                    o.GetComponentInChildren<Outline>().effectColor = thiscard.cardColor();
                    o.transform.position = Camera.main.WorldToScreenPoint(new Vector3(cst.transform.position.x, cst.transform.position.y + 6.5f, -1));
                    o.GetComponent<ActionUI>().caster = cst;

                    onDestroy = true;
                    BattleManager.selectedCharacter.canTakeAction = false;
                    BattleManager.selectedCharacter = null;

                    //Readjust the cardIndex to account for one less card
                    foreach (DisplayCard c in GameObject.FindObjectsOfType<DisplayCard>())
                    {
                        if (c.cardIndex > cardIndex)
                        {
                            c.cardIndex--;
                        }
                    }

                    activeCards--;
                    cardIndex = -1;

                    Deck.discard.Add(thiscard);
                }
                //If a card wasn't activated, return it to it's old pivot point
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - (rt.rect.height / 2));
                    rt.pivot = new Vector2(0.5f, 0f);
                }
            }
        }
    }

    public void DiscardThis()
    {
        onDestroy = true;
        Deck.discard.Add(thiscard);

        foreach (DisplayCard c in GameObject.FindObjectsOfType<DisplayCard>())
        {
            if (c.cardIndex > cardIndex)
            {
                c.cardIndex--;
            }
        }

        activeCards--;
        cardIndex = -1;
    }

    public bool canPlayType(Card.CardTypes t)
    {
        

        if (BattleManager.selectedCharacter == null)
        {
            return false;
        }

        if (thiscard.Bound() != null && !thiscard.Bound().Equals(BattleManager.selectedCharacter.thisChar.cName))
        {
            return false;
        }

        if (t == Card.CardTypes.None)
        {
            return true;
        }

        return BattleManager.selectedCharacter.thisChar.types[0] == t || BattleManager.selectedCharacter.thisChar.types[1] == t;
    }
}
