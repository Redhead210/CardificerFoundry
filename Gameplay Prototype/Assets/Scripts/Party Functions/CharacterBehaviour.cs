/**
// File Name :         CharacterBehaviour.cs
// Author :            Jason Czech, Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Contains all refrecnces nessacary to build a character
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterBehaviour : MonoBehaviour
{
    public bool isEnemy;
    public int partyIndex;

    GameObject platform;
    List<string> enemyAttackQueue;
    string[] enemyAttacks;

    public Text txt;
    public Slider healthbar;
    public SpriteRenderer ot;
    SpriteRenderer sr;

    public Image emblem1;
    public Image emblem2;

    public Character thisChar;

    // None highlight / default
    public Sprite otn;
    // Green highlight
    public Sprite otg;
    // White highlight
    public Sprite otw;
    // Yellow highlight
    public Sprite oty;
    // Grey highlight
    public Sprite otgry;

    public Sprite otn2;
    public Sprite otg2;
    public Sprite otw2;
    public Sprite oty2;
    public Sprite otgry2;

    public Sprite otn3;
    public Sprite otg3;
    public Sprite otw3;
    public Sprite oty3;
    public Sprite otgry3;

    public bool canTakeAction = true;

    public int ptColor = 0;
    public int block = 0;

    public List<StatusEffect> statusEffects = new List<StatusEffect>();

    public GameObject seUIPrefab;
    public GameObject cardPrefab;
    GameObject targetObj;
    public GameObject PauseMenu;

    void Start()
    {
        if (GameManager.act == 1)
        {
            platform = Instantiate(FindObjectOfType<Deck>().platformPrefab2, (Vector2)transform.position, Quaternion.identity);
        }
        else if (GameManager.act == 2 || GameManager.act == 3)
        {
            platform = Instantiate(FindObjectOfType<Deck>().platformPrefab3, (Vector2)transform.position, Quaternion.identity);
        }
        else
        {
            platform = Instantiate(FindObjectOfType<Deck>().platformPrefab, (Vector2)transform.position, Quaternion.identity);
        }
        platform.transform.position = new Vector3(transform.position.x, transform.position.y, 2);
        platform.transform.parent = transform.parent;
        ot = platform.GetComponent<SpriteRenderer>();

        healthbar = Instantiate(GameManager.gm.hpbPrefab).GetComponent<Slider>();
        healthbar.transform.SetParent(FindObjectOfType<Canvas>().transform);

        if (!isEnemy)
        {
            emblem1.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x - 2.1f, transform.position.y - 2.1f, -5));
            emblem2.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + 2.3f, transform.position.y - 2.1f, -5));
        }

        txt.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y - 1.45f));
        healthbar.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y - 2.1f));

        targetObj = Instantiate(GameManager.gm.tgtPrefab);
        targetObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        Activate();
    }

    /// <summary>
    /// Updates data and re-enables UI for a Character gameObject
    /// </summary>
    public void Activate()
    {
        statusEffects.Clear();

        bool exist = true;

        if (!isEnemy)
        {
            emblem1.gameObject.SetActive(true);
            emblem2.gameObject.SetActive(true);
        }
        healthbar.gameObject.SetActive(true);
        txt.gameObject.SetActive(true);
        platform.gameObject.SetActive(true);

        sr = GetComponent<SpriteRenderer>();
        if (isEnemy)
        {
            if (Party.enemyParty.Length > partyIndex)
            {
                thisChar = Party.enemyParty[partyIndex];
                enemyAttacks = Party.enemyParty[partyIndex].deck;
                enemyAttackQueue = new List<string>(Party.enemyParty[partyIndex].deck);
                if (Party.enemyParty[partyIndex].effects != null)
                {
                    foreach (string e in Party.enemyParty[partyIndex].effects)
                    {
                        var a = e.Split(' ');
                        ApplyEffect(a[0], int.Parse(a[1]));
                    }
                }

                GetComponent<SpriteRenderer>().sprite = Party.enemyParty[partyIndex].sprite;
                Deck.Shuffle(enemyAttackQueue);
                thisChar.hp = thisChar.maxhp;
            }
            else
            {
                exist = false;
            }
        }
        else
        {
            if (Party.party.Length > partyIndex)
            {
                thisChar = Party.party[partyIndex];
                healthbar.maxValue = thisChar.maxhp;
                healthbar.value = thisChar.hp;
                GetComponent<CustomCharacterDisplay>().character = thisChar;
                emblem1.GetComponent<Image>().sprite = GameManager.gm.characterEmblem[(int)thisChar.types[0]];
                emblem2.GetComponent<Image>().sprite = GameManager.gm.characterEmblem[(int)thisChar.types[1]];

            }
            else
            {
                exist = false;
                emblem1.sprite = null;
                emblem2.sprite = null;
            }

        }

        if (exist)
        {
            txt.color = Color.white;
            sr.color = Color.white;

            healthbar.maxValue = thisChar.maxhp;
            healthbar.value = thisChar.hp;
            txt.text = thisChar.cName;

            
        }
        else
        {
            txt.text = "";
            sr.sprite = null;
            healthbar.gameObject.SetActive(false);
            platform.gameObject.SetActive(false);
            if (!isEnemy)
            {
                emblem1.gameObject.SetActive(false);
                emblem2.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
        
    }

    
        
    void Update()
    {
        if(PauseMenu.activeInHierarchy == false)
        {
            if (thisChar != null)
            {
                healthbar.maxValue = thisChar.maxhp;
                if (BattleManager.selectedCharacter == null)
                {
                    //Target Hover Alpha for enemies
                    var sr = targetObj.GetComponent<SpriteRenderer>();
                    var t = targetObj.transform.position;
                    if (sr.color.a != 0)
                    {
                        if (MouseInHitbox())
                        {
                            sr.color = Color.Lerp(sr.color, new Color(1, 1, 1, 1), 10 * Time.deltaTime);
                            targetObj.transform.position = new Vector3(t.x, t.y, -2);
                        }
                        else
                        {
                            sr.color = Color.Lerp(sr.color, new Color(0.75f, 0.75f, 0.75f, 0.4f), 10 * Time.deltaTime);
                            targetObj.transform.position = new Vector3(t.x, t.y, -1);
                        }
                    }
                }
                else
                {
                    targetObj.GetComponent<SpriteRenderer>().color = Color.Lerp(targetObj.GetComponent<SpriteRenderer>().color, new Color(0.75f, 0.75f, 0.75f, 0f), 5 * Time.deltaTime);
                }


                //Sets platform colors based on ptColor
                if (GameManager.act == 1)
                {
                    switch (ptColor)
                    {
                        case 0:
                            ot.sprite = otn2;
                            break;
                        case 1:
                            ot.sprite = otw2;
                            break;
                        case 3:
                            ot.sprite = oty2;
                            break;
                        case 4:
                            ot.sprite = otgry2;
                            break;
                    }
                }
                else if (GameManager.act == 2 || GameManager.act == 3)
                {
                    switch (ptColor)
                    {
                        case 0:
                            ot.sprite = otn3;
                            break;
                        case 1:
                            ot.sprite = otw3;
                            break;
                        case 3:
                            ot.sprite = oty3;
                            break;
                        case 4:
                            ot.sprite = otgry3;
                            break;
                    }
                }
                else
                {
                    switch (ptColor)
                    {
                        case 0:
                            ot.sprite = otn;
                            break;
                        case 1:
                            ot.sprite = otw;
                            break;
                        case 3:
                            ot.sprite = oty;
                            break;
                        case 4:
                            ot.sprite = otgry;
                            break;
                    }
                }

                //Character action selection
                if (BattleManager.selectedCharacter == null && !isEnemy)
                {
                    //If they're avaliable
                    if (canTakeAction)
                    {
                        //And you're hovering over them, make it green
                        if (MouseInHitbox())
                        {
                            if(GameManager.act == 1)
                            {
                                ot.sprite = otg2;
                            }
                            else if(GameManager.act == 2 || GameManager.act == 3)
                            {
                                ot.sprite = otg3;
                            }
                            else
                            {
                                ot.sprite = otg;
                            }
                            //If you click it, select it
                            if (Input.GetMouseButtonDown(0))
                            {
                                BattleManager.selectedCharacter = this;
                            }
                        }
                        //If you're not hovering over it, make it yellow
                        else
                        {
                            if (GameManager.act == 1)
                            {
                                ot.sprite = oty2;
                            }
                            else if (GameManager.act == 2 || GameManager.act == 3)
                            {
                                ot.sprite = oty3;
                            }
                            else
                            {
                                ot.sprite = oty;
                            }
                        }
                    }
                    //If it's not avaliable, make it grey
                    else
                    {
                        if (GameManager.act == 1)
                        {
                            ot.sprite = otgry2;
                        }
                        else if (GameManager.act == 2 || GameManager.act == 3)
                        {
                            ot.sprite = otgry3;
                        }
                        else
                        {
                            ot.sprite = otgry;
                        }
                    }
                }
                //If it's already selected,  make it white
                else if (BattleManager.selectedCharacter == this)
                {
                    if (GameManager.act == 1)
                    {
                        ot.sprite = otw2;
                    }
                    else if (GameManager.act == 2 || GameManager.act == 3)
                    {
                        ot.sprite = otw3;
                    }
                    else
                    {
                        ot.sprite = otw;
                    }

                    //If you click on it, deselect it
                    if (Input.GetMouseButtonDown(0) && MouseInHitbox())
                    {
                        BattleManager.selectedCharacter = null;
                    }
                }

                if (ptColor == 2)
                {
                    if (GameManager.act == 1)
                    {
                        ot.sprite = otg2;
                    }
                    else if (GameManager.act == 2 || GameManager.act == 3)
                    {
                        ot.sprite = otg3;
                    }
                    else
                    {
                        ot.sprite = otg;
                    }
                }

                //If the manager is figuring out actions, remove the outline
                if (BattleManager.IsCalculating)
                {
                    if (GameManager.act == 1)
                    {
                        ot.sprite = otn2;
                    }
                    else if (GameManager.act == 2 || GameManager.act == 3)
                    {
                        ot.sprite = otn3;
                    }
                    else
                    {
                        ot.sprite = otn;
                    }
                }

                //Block UI
                healthbar.GetComponentInChildren<BlockUIBehaviour>().block = block;


                var m = 1;
                var dif = Mathf.Abs(healthbar.value - thisChar.hp);
                if (dif >= 100)
                {
                    m = 30;
                }
                else if (dif >= 50)
                {
                    m = 10;
                }
                

                //Smooth healthbar
                if (healthbar.value > thisChar.hp)
                {
                    

                    healthbar.value -= Time.deltaTime * 5 * m;
                }

                if (healthbar.value < thisChar.hp)
                {
                    healthbar.value += Time.deltaTime * 5 * m;
                }


                //Death fade out
                if (healthbar.value == 0)
                {
                    sr.color = Color.Lerp(sr.color, new Color(0, 0, 0, 0), Time.deltaTime * 5);
                    txt.color = Color.Lerp(txt.color, new Color(0, 0, 0, 0), Time.deltaTime * 5);

                    if (isEnemy)
                    {
                        foreach (AttackUIBehaviour a in FindObjectsOfType<AttackUIBehaviour>())
                        {
                            if (a.caster == this)
                            {
                                a.fade = false;
                            }
                        }
                    }

                    //On death
                    if (sr.color.a <= 0.1f)
                    {
                        if (!isEnemy)
                        {
                            var p = new Character[Party.party.Length - 1];
                            for (int i = 0; i < p.Length; i++)
                            {
                                if (i < partyIndex)
                                {
                                    p[i] = Party.party[i];
                                }
                                else
                                {
                                    p[i] = Party.party[i + 1];
                                }
                            }
                            Party.party = p;

                            targetObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                            emblem1.gameObject.SetActive(false);
                            emblem2.gameObject.SetActive(false);
                        }

                        gameObject.SetActive(false);
                        healthbar.gameObject.SetActive(false);
                        //txt.gameObject.SetActive(false);
                        txt.text = "";
                        if(GameManager.act == 1)
                        {
                            platform.GetComponent<SpriteRenderer>().sprite = otn2;
                        }
                        else if(GameManager.act == 2 || GameManager.act == 3)
                        {
                            platform.GetComponent<SpriteRenderer>().sprite = otn3;
                        }
                        else
                        {
                            platform.GetComponent<SpriteRenderer>().sprite = otn;
                        }

                        if (!isEnemy)
                        {
                            Deck.RefreshDeck();
                        }

                        foreach (StatusEffectUIBehaviour ui in GetCBStatusUI())
                        {
                            Destroy(ui.gameObject);
                        }
                    }
                }
            }
        }
        
    }

    public void LateUpdate()
    {
        if (thisChar != null)
        {
            UpdateEffectUI();
        }
        
    }

    public bool MouseInHitbox()
    {
        var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var w = 2.25f;
        var d = 1f;
        var h = 6f;

        var x = transform.position.x;
        var y = transform.position.y;

        if (p.x < x-w)
        {
            return false;
        }
        if (p.x > x+w)
        {
            return false;
        }
        if (p.y < y-d)
        {
            return false;
        }
        if (p.y > y+h)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Gets an array of CharacterBehaviours that are storing enemies
    /// </summary>
    /// <returns>Array of CharacterBehaviours that are storing enemies</returns>
    public static CharacterBehaviour[] getAllEnemies()
    {
        var a = new List<CharacterBehaviour>(FindObjectsOfType<CharacterBehaviour>());

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i]!=null&&(!a[i].isEnemy && a[i].gameObject.activeSelf) || a[i].thisChar.hp <= 0)

            {
                a.RemoveAt(i);

                i--;
            }

        }

        return a.ToArray();
    }

    /// <summary>
    /// Gets an array of CharacterBehaviours that are storing player characters
    /// </summary>
    /// <returns>Array of CharacterBehaviours that are storing pcs</returns>
    public static CharacterBehaviour[] getAllPlayers()
    {
        var a = new List<CharacterBehaviour>(FindObjectsOfType<CharacterBehaviour>());

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i].thisChar == null || (a[i].isEnemy && a[i].gameObject.activeSelf) || a[i].thisChar.hp <= 0)
            {
                a.RemoveAt(i);
                i--;
            }
        }

        return a.ToArray();
    }

    public static CharacterBehaviour[] getAllAlive()
    {
        var a = new List<CharacterBehaviour>(FindObjectsOfType<CharacterBehaviour>());

        for (int i = 0; i < a.Count; i++)
        {
            if (!a[i].gameObject.activeSelf || a[i].thisChar == null || a[i].thisChar.hp <= 0)
            {
                a.RemoveAt(i);
                i--;
            }
        }

        return a.ToArray();
    }

    public EnemyAttack GetNextAttack()
    {
        if (enemyAttackQueue.Count == 0)
        {
            enemyAttackQueue = new List<string>(enemyAttacks);
            Deck.Shuffle(enemyAttackQueue);
        }

        var s = enemyAttackQueue[0];
        enemyAttackQueue.RemoveAt(0);

        EnemyAttack e = (EnemyAttack)Activator.CreateInstance(Type.GetType(s));

        if (e.CanBeUsed())
        {
            return e;
        }
        else
        {
            return GetNextAttack();
        }
    }

    public void ShowMessage(string msg, Color c)
    {
        var t = FloatingText.Create(new Vector2(transform.position.x, transform.position.y + 7), msg);
        t.GetComponent<Outline>().effectColor = c;
    }

    public void ApplyEffect(string name, int amount)
    {
        name = name.ToLower();

        GameObject o;

        //Makes sure that there's only 1 taunting ally or enemy;
        if (name.Equals("taunt"))
        {
            CharacterBehaviour[] a;
            if (isEnemy)
            {
                a = getAllEnemies();
            }
            else
            {
                a = getAllPlayers();
            }

            foreach (CharacterBehaviour c in a)
            {
                if (c != this && c.HasEffect("taunt"))
                {
                    c.SubtractEffect("taunt", c.EffectStacks("taunt"));
                    break;
                }
            }
        }

        var index = EffectIndex(name);
        //Add to an existing effect if one is active
        if (index != -1)
        {
            statusEffects[index].stacks += amount;
            o = StatusEffectUIBehaviour.GetStatusUIofType(this, statusEffects[index].name).gameObject;
        }
        //Create a new EffectUI and add to the statusEffects list
        else
        {
            var se = new StatusEffect(amount, name);

            o = Instantiate(seUIPrefab);
            var ui = o.GetComponent<StatusEffectUIBehaviour>();
            ui.SEArrayIndex = statusEffects.Count;
            ui.cb = this;
            statusEffects.Add(se);


            o.transform.SetParent(FindObjectOfType<Canvas>().gameObject.transform);
        }
    }

    public void SubtractEffect(string name, int amount)
    {
        var index = EffectIndex(name);
        if (index != -1)
        {
            statusEffects[index].stacks -= amount;

            var s = statusEffects[index].name;
            var o = StatusEffectUIBehaviour.GetStatusUIofType(this, s).gameObject;

            if (statusEffects[index].stacks <= 0)
            {
                Destroy(StatusEffectUIBehaviour.GetStatusUIofType(this, s).gameObject);
                statusEffects.RemoveAt(index);
            }

        }
    }

    public int EffectIndex(string name)
    {
        for (int i = 0; i < statusEffects.Count; i++)
        {
            if (statusEffects[i].name.Equals(name))
            {
                return i;
            }
        }
        return -1;
    }

    public bool HasEffect(string name)
    {
        for (int i = 0; i < statusEffects.Count; i++)
        {
            if (statusEffects[i].name.Equals(name))
            {
                return true;
            }
        }
        return false;
    }

    public int EffectStacks(string name)
    {
        var ind = EffectIndex(name);
        if (ind == -1)
        {
            return 0;
        }

        return statusEffects[ind].stacks;
    }

    public void UpdateEffectUI()
    {
        var a = GetCBStatusUI();
        for (int i = 0; i < statusEffects.Count; i++)
        {
            a[i].SEArrayIndex = i;
        }

        if (a.Length != 0)
        {
            for (int i = 0; i < statusEffects.Count; i++)
            {
                a[i].transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x + (i - (a.Length / 2)), transform.position.y - 3.1f));

                if (a[i].txt != null)
                {
                    var s = "" + statusEffects[a[i].SEArrayIndex].stacks;
                    a[i].txt.text = s;
                    s = statusEffects[a[i].SEArrayIndex].name;
                    a[i].txt1.text = char.ToUpper(s[0]) + s.Substring(1);
                    a[i].img.sprite = statusEffects[a[i].SEArrayIndex].icon;
                }
            }
        }
    }

    public StatusEffectUIBehaviour[] GetCBStatusUI()
    {
        var l = new List<StatusEffectUIBehaviour>();
        foreach (StatusEffectUIBehaviour ui in FindObjectsOfType<StatusEffectUIBehaviour>())
        {
            if (ui.cb == this)
            {
                l.Add(ui);
            }
        }

        return l.ToArray();
    }

    public int TakeDamage(int amount, string msg = "")
    {
        if (HasEffect("mark"))
        {
            amount = (int)(amount * 2);
            SubtractEffect("mark", 1);
            msg = "Crit!";
        }
        if (BattleManager.currentlyActing != null)
        {
            amount += Mathf.Max(0, BattleManager.currentlyActing.EffectStacks("power"));
        }


        var r = Mathf.Min(thisChar.hp, amount - block);

        var p = transform.position;

        if (!msg.Equals(""))
        {
            FloatingText.Create(new Vector2(p.x, p.y - 0f), msg);
        }

        if (block > 0)
        {
            var f = FloatingText.Create(new Vector2(p.x, p.y - 0), "-" + Mathf.Min(amount, block));
            f.GetComponent<Outline>().effectColor = Color.cyan;
        }

        block -= amount;
        if (block < 0)
        {
            thisChar.hp += block; ;
            block = 0;
        }

        FloatingText.Create(new Vector2(p.x, p.y - 0.5f), "-" + Mathf.Max(r, 0));

        return Mathf.Max(r, 0);
    }

    public static CharacterBehaviour getHighestHP(CharacterBehaviour[] array)
    {
        if (array.Length == 0)
        {
            return null;
        }

        CharacterBehaviour t = array[0];
        foreach (CharacterBehaviour c in array)
        {
            if (c != null && c.thisChar != null && c.thisChar.hp > t.thisChar.hp)
            {
                t = c;
            }
        }

        return t;
    }

    public static CharacterBehaviour getLowestHP(CharacterBehaviour[] array)
    {
        CharacterBehaviour t = array[0];
        foreach (CharacterBehaviour c in array)
        {
            if (c != null && c.thisChar != null && c.thisChar.hp > 0 && c.thisChar.hp < t.thisChar.hp)
            {
                t = c;
            }
        }

        return t;
    }

    public int GetPositionInQueue()
    {
        int p = 0;
        bool found = false;
        foreach (AttackData a in BattleManager.queue)
        {
            p++;
            if (a.caster == this)
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            return p;
        }
        return -1;
    }

    public CharacterBehaviour GetQueuedTarget()
    {
        foreach (AttackData a in BattleManager.queue)
        {
            if (a.caster == this)
            {
                return a.target;
            }
        }
        return null;
    }

    public void TargetUIUpdate()
    {
        var t = GetQueuedTarget();
        if (thisChar.hp <= 0 || t != null)
        {
            targetObj.transform.position = new Vector3(t.transform.position.x, t.transform.position.y, -1);
            targetObj.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 0.4f);
        }
        else
        {
            targetObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    public int Heal(int amount)
    {
        if (HasEffect("radiance"))
        {
            var a = EffectStacks("radiance");

            CharacterBehaviour[] c;
            if (isEnemy)
            {
                c = getAllPlayers();
            }
            else
            {
                c = getAllEnemies();
            }

            foreach (CharacterBehaviour cb in c)
            {
                cb.TakeDamage(a);
            }
        }

        var r = Mathf.Min(thisChar.maxhp - thisChar.hp, amount);

        thisChar.hp = Mathf.Min(thisChar.maxhp, thisChar.hp + amount);
        var p = transform.position;

        var t = FloatingText.Create(new Vector2(p.x, p.y - 0.5f), "+" + r);
        t.GetComponent<Outline>().effectColor = Color.green;

        return r;
    }

    public bool HasActed()
    {
        foreach (AttackData a in BattleManager.queue)
        {
            if (a.caster == this)
            {
                return false;
            }
        }

        return true;
    }

    public void SetEffect(string name, int amount)
    {
        if (amount == 0)
        {
            RemoveEffect(name);
        }
        else if (HasEffect(name))
        {
            statusEffects[EffectIndex(name)].stacks = amount;
        }
        else
        {
            ApplyEffect(name, amount);
        }
    }

    public void RemoveEffect(string name)
    {
        if (HasEffect(name))
        {
            var index = EffectIndex(name);

            Destroy(StatusEffectUIBehaviour.GetStatusUIofType(this, name).gameObject);
            statusEffects.RemoveAt(index);
        }
    }

    public void RemoveAllEffects()
    {
        foreach (StatusEffect effect in statusEffects)
        {
           RemoveEffect(effect.name);
        }
    }

    public static CharacterBehaviour GetCharAtIndex(bool isEnemy, int index)
    {
        foreach (CharacterBehaviour c in FindObjectsOfType<CharacterBehaviour>())
        {
            if (c.isEnemy == isEnemy && c.partyIndex == index)
            {
                return c;
            }
        }

        return null;
    }

    public void Particle(BattleManager.Effects e)
    {
        BattleManager.spawnEffect(e, this);
    }
}