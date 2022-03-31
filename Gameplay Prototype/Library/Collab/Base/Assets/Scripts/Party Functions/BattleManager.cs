/**
// File Name :         BattleManager.cs
// Author :            Jason Czech
// Creation Date :     1/26/2021
//
// Brief Description : Handles all of combat
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public static List<AttackData> queue = new List<AttackData>();
    public static int turns;
    public GameObject[] visualEffects;
    public enum Effects { Slash, Block, Regen, Toxin, Punch, Taunt, Power};
    public Button endTurn;
    public GameObject enemyPartyPrefab;
    
    public GameObject fadeOut;
    public static CharacterBehaviour currentlyActing;
    public GameObject[] characterSlots = new GameObject[6];
    public static CharacterBehaviour selectedCharacter;
    public static bool IsCalculating = false;
    public static int innovate = 0;
    public Text turnTimer;
    public bool battleEnded = false;
    bool isDead = false;
    public int wingold;
    public int winxp;

    public static BattleManager bm;

    //This function activates when the battle starts.
    public void StartBattle()
    {
        battleEnded = false;
        endTurn.interactable = true;
        TransitionManager.TransitionDown();
        GetComponent<Deck>().enabled = true;

        //Enemies are harder after the miniboss
        /*
        if (GameManager.floor > 4 && GameManager.floor != 7)
        {
            foreach(CharacterBehaviour en in CharacterBehaviour.getAllEnemies())
            {
                en.ApplyEffect("power", 2);
                en.thisChar.maxhp = (int)(en.thisChar.maxhp * 1.5f);
            }
        }
        */

        innovate = 0;
        turns = 1;
        turnTimer.text = "Turn " + turns;

        //Deactivates Grid
        GameManager.gm.isoGridManager.SetActive(false);

        //Resets character selectors
        selectedCharacter = null;
        currentlyActing = null;

        //Refreshes all character actions
        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            c.canTakeAction = true;
            c.txt.color = new Color(1, 1, 1, 1);
        }

        //Resets Card UI positioning
        DisplayCard.activeCards = 0;

        //Activates dead CharacterBehaviors
        foreach(GameObject o in characterSlots)
        {
            if (!o.activeSelf)
            {
                o.SetActive(true);
                o.GetComponent<CharacterBehaviour>().Activate();
            }
        }
        

        //Queues enemy attacks
        Invoke("QueueEnemyAttacks", 0.01f);
    }

    void Start()
    {
        fadeOut.SetActive(false);

        bm = this;
        //Makes EndTurn button work
        endTurn.onClick.AddListener(resolveQueue);
        if(GameManager.fireTrapBurn)
        {
            foreach(CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
            {
                if(GameManager.act == 1)
                {
                    c.ApplyEffect("burn", 3);
                }
                else
                {
                    c.ApplyEffect("burn", 4);
                }
            }
        }
    }

    void Update()
    {
        if (isDead==true)
        {
            Darken();
        }

        IsCalculating = IsInvoking();

        //If all enemies are dead, end the battle
        if (CharacterBehaviour.getAllEnemies().Length == 0 && !battleEnded)
        {
            battleEnded = true;
           
            EndBattle();
        }
        //If all players are dead, quit the game
        else if (CharacterBehaviour.getAllPlayers().Length == 0)
        {
            isDead = true;
        }
    }

    public void Darken()
    {
        queue.Clear();

        fadeOut.SetActive(true);

        float aChange = 0.5f*Time.deltaTime;
        Color newColor = fadeOut.GetComponent<Image>().color;
        newColor.a += aChange;

        fadeOut.GetComponent<Image>().color= newColor;

        if (fadeOut.GetComponent<Image>().color.a >= 1)
        {
            Party.ResetParty();
            SceneManager.LoadScene("Game Over");
        }
    }

    public void resolveQueue()
    {
        endTurn.interactable = false;

        foreach (ActionUI a in FindObjectsOfType<ActionUI>())
        {
            Destroy(a.gameObject);
        }

        //Fades AttackUIs to deletion
        foreach (AttackUIBehaviour ui in FindObjectsOfType<AttackUIBehaviour>())
        {
            ui.fade = false;
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
        {
            //Clears unused actions
            c.canTakeAction = false;

            //Redirects attacks to taunting characters
            if (c.HasEffect("taunt"))
            {
                foreach (AttackData a in queue)
                {
                    if (a.allignment == AttackData.Side.Enemy)
                    {
                        a.target = c;
                    }
                }
            }
        }

        //Makes targetUIs disappear
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("TargetUI"))
        {
            o.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }

        //Begins executing actions
        InvokeRepeating("queueAttack",2,2);
    }

    public void queueAttack()
    {
        //Ends invokeRepeating when there are no more actions and runs EndTurn
        if (queue.Count == 0)
        {
            EndOfTurn();
            Debug.Log("Queue Over");
            CancelInvoke("queueAttack");
        }
        else
        {
            //Sorts actions by speed
            queue.Sort();

            AttackData ad = queue[0];
            currentlyActing = ad.caster;
            queue.RemoveAt(0);

            //If the caster isn't dead
            if (ad.caster.thisChar.hp > 0)
            {
                if (!(ad.targeting && ad.target == null))
                {
                    ad.Cast();
                }

                //Text that pops up with move name
                var p = ad.caster.transform.position;
                FloatingText.Create(new Vector2(p.x,p.y+6), ad.aName);

                //If all enemies are dead end the battle
                if (CharacterBehaviour.getAllEnemies().Length == 0)
                {
                    CancelInvoke("queueAttack");
                    EndBattle();
                }
                //If all players are dead end the game
                else if (CharacterBehaviour.getAllPlayers().Length ==0)
                {
                    isDead = true;
                }
            }
            else
            {
                queueAttack();
            }
        }
    }

    public void EndBattle()
    {
        if (HPUpdated())
        {
            Debug.Log("End Battle");
            TransitionManager.TransitionUp();
            ActuallyEndBattle();
        }
        else
        {
            Invoke("EndBattle", 1);
        }
    }

    public void EndOfTurn()
    {
        selectedCharacter = null;
        currentlyActing = null;
        turns++;
        turnTimer.text = "Turn " + turns;
        endTurn.interactable = true;
       

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllAlive())
        {
            //Refresh actions
            c.canTakeAction = true;

            //Cuts block in half
            c.block /= 2;

            //Reduces Taunt effect by 1
            if (c.thisChar.hp > 0 && c.HasEffect("taunt"))
            {
                c.SubtractEffect("taunt", 1);
            }

            //Deals Toxin damage and reduces it by 1
            if (c.thisChar.hp > 0 && c.HasEffect("toxin"))
            {
                c.TakeDamage(2+GameManager.act);
                c.SubtractEffect("toxin", 1);
            }

            //Deals Burn damage and reduces it by 1
            if (c.thisChar.hp > 0 && c.HasEffect("burn"))
            {
                c.TakeDamage(c.EffectStacks("burn"));
                c.SubtractEffect("burn", Mathf.RoundToInt(c.EffectStacks("burn")/2));
            }

            //Heals Regen and reduces it by 1
            if (c.thisChar.hp > 0 && c.HasEffect("regen"))
            {
                var s = c.EffectStacks("regen");
                if (s > 10) {
                    c.SubtractEffect("regen", s - 10);
                    s = Mathf.Min(10, s);
                }
                c.Heal(s);
                c.SubtractEffect("regen", 1);
            }
        }

        //Discards leftover cards
        foreach (DisplayCard d in FindObjectsOfType<DisplayCard>())
        {
            d.DiscardThis();
        }

        QueueEnemyAttacks();
    }

    public static void RefreshTargetUI()
    {
        //Updates the target UI to match what the enemies are targeting
        foreach (AttackData a in queue)
        {
            a.caster.TargetUIUpdate();
        }
    }

    public void QueueEnemyAttacks()
    {
        foreach(CharacterBehaviour c in CharacterBehaviour.getAllAlive())
        {
            if (c.HasEffect("armor"))
            {
                c.block += c.EffectStacks("armor");
            }
        }

        foreach (CharacterBehaviour c in CharacterBehaviour.getAllEnemies())
        {
            //Add attack to the queue
            var a = c.GetNextAttack();
            queue.Add(new AttackData(a,c));

            var o = Instantiate(GameManager.gm.atkPrefab, FindObjectOfType<Canvas>().transform, false);
            o.transform.position = Camera.main.WorldToScreenPoint(new Vector3(c.transform.position.x, c.transform.position.y + 6.5f, -1));
            o.GetComponent<AttackUIBehaviour>().caster = c;
        }

        queue.Sort();

        foreach(AttackData a in queue)
        {
            var c = a.thisAttack.caster;
            if (c.isEnemy)
            {
                var o = Instantiate(GameManager.gm.atkPrefab, FindObjectOfType<Canvas>().transform, false);
                
                o.transform.position = Camera.main.WorldToScreenPoint(new Vector3(c.transform.position.x, c.transform.position.y + 6.5f, -1));
                o.GetComponent<AttackUIBehaviour>().caster = c;
            }
        }

        RefreshTargetUI();
    }

    bool HPUpdated()
    {
        Debug.Log("HPCheck");
        foreach(CharacterBehaviour c in FindObjectsOfType<CharacterBehaviour>())
        {
            if (Mathf.RoundToInt(c.healthbar.value) != c.thisChar.hp)
            {
                return false;
            }
        }
        return true;
    }

    void ActuallyEndBattle()
    {
        if (TransitionManager.inMiddle)
        {
            queue.Clear();

            //Clear all status effects and removes extra block
            foreach (CharacterBehaviour c in CharacterBehaviour.getAllPlayers())
            {
                c.statusEffects.Clear();
                c.block = 0;
            }

            //Removes status effect UI
            foreach (StatusEffectUIBehaviour c in FindObjectsOfType<StatusEffectUIBehaviour>())
            {
                Destroy(c.gameObject);
            }

            //Destroys card UI
            foreach (DisplayCard c in FindObjectsOfType<DisplayCard>())
            {
                Destroy(c.gameObject);
            }

            //Makes targetUIs disappear
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("TargetUI"))
            {
                o.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
            }

            selectedCharacter = null;

            queue.Clear();

            GameManager.money += 150;

            for (int i = 0; i < Party.party.Length; i++)
            {
                Character c = Party.party[i];
                c.xp += winxp;
                while (c.xp >= GameManager.XPtoLevel * c.level)
                {
                    c.xp -= GameManager.XPtoLevel * c.level;
                    c.level++;
                    c.maxhp += c.hpmod;
                    c.hp += c.hpmod;
                }
            }

            //Disables Combat and enables Grid
            GameManager.gm.isoGridManager.SetActive(true);
            GameManager.gm.combatManager.SetActive(false);
        }
        else
        {
            Invoke("ActuallyEndBattle", 0.001f);
        }
    }

    public static void spawnEffect(Effects e, CharacterBehaviour c)
    {
        Instantiate(bm.visualEffects[(int)e], c.transform.position, Quaternion.identity);
    }
}
