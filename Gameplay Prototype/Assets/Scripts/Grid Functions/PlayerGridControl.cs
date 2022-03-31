/**
// File Name :         PlayerGridControl.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Handles player movement on the map and certain tiles 
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGridControl : GridMovement
{
    bool enemiesNotMoving = true;
    bool enterCombat = false;
    GameObject triggeredEnemy;
    private SpriteRenderer bodySR;
    private SpriteRenderer headSR;
    private SpriteRenderer hatSR;
    public bool pauseMenuActive;
    public GameObject PauseMenu;

    public Sprite blankTile;
    public Sprite leverOn;

    public Sprite act2BlankTile;
    public Sprite act2LeverOn;

    public Sprite act3BlankTile;
    public Sprite act3LeverOn;

    public Sprite act2FireTrapOn;
    public Sprite act3FireTrapOn;
    public Sprite act2FireTrapOff;
    public Sprite act3FireTrapOff;
    public Sprite act2FireTrapPrepare;
    public Sprite act3FireTrapPrepare;
    private int cycle = 1;


    void Start()
    {
        bodySR = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        headSR = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        hatSR = gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();
        tile_x = IsoGridGenerator.startX;
        tile_y = IsoGridGenerator.startY;

        var new_x = start_pos.x + (tile_x * 2) + (tile_y * 2);
        var new_y = start_pos.y + tile_x - tile_y;
        gameObject.transform.position = new Vector3(new_x, new_y, -10 - tile_y);
        Invoke("RefreshCharacter", 0.01f);
    }

    void RefreshCharacter()
    {
        GetComponent<CustomCharacterDisplay>().character = Party.party[0];
        GetComponent<CustomCharacterDisplay>().Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        pauseMenuActive = PauseMenu.activeInHierarchy;

        var moving = !transform.position.Equals(moveTowards);

        if (!GameManager.inTutorialText)
        {
            if (!moving)
            {
                if (enterCombat)
                {
                    if (!IsInvoking("EnterCombat"))
                    {
                        Invoke("EnterCombat", 0.5f);
                        TransitionManager.TransitionDown();
                    }
                }
                else
                {
                    if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && canMove(tile_x, tile_y + 1) && enemiesNotMoving == true && pauseMenuActive == false)
                    {
                        bodySR.flipX = true;
                        headSR.flipX = true;
                        hatSR.flipX = true;
                        tile_y++;
                        enemiesNotMoving = false;
                        Invoke("moveAllEnemies", .5f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canMove(tile_x, tile_y - 1) && enemiesNotMoving == true && pauseMenuActive == false)
                    {
                        bodySR.flipX = false;
                        headSR.flipX = false;
                        hatSR.flipX = false;
                        tile_y--;
                        enemiesNotMoving = false;
                        Invoke("moveAllEnemies", .5f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && canMove(tile_x - 1, tile_y) && enemiesNotMoving == true && pauseMenuActive == false)
                    {
                        bodySR.flipX = false;
                        headSR.flipX = false;
                        hatSR.flipX = false;
                        tile_x--;
                        enemiesNotMoving = false;
                        Invoke("moveAllEnemies", .5f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && canMove(tile_x + 1, tile_y) && enemiesNotMoving == true && pauseMenuActive == false)
                    {
                        bodySR.flipX = true;
                        headSR.flipX = true;
                        hatSR.flipX = true;
                        tile_x++;
                        enemiesNotMoving = false;
                        Invoke("moveAllEnemies", .5f);
                    }
                }
            }
        }
        

        updateWorldPos();
    }

    /// <summary>
    /// Moves all enemies on the grid and checks for combat encounters
    /// </summary>
    void moveAllEnemies()
    {
        enemiesNotMoving = true;

        List<GameObject> FireTiles;

        // Checks for fire traps
        try
        {
            FireTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Fire);
            // If there are no fire tiles, will break to the catch statement and skip these if statements
            if (cycle == 1)
            {
                cycle++;
            }
            else if (cycle == 2)
            {
                // about to turn on
                //List<GameObject> mapTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Fire);
                foreach (GameObject t in FireTiles)
                {
                    if (GameManager.act == 1)
                    {
                        t.GetComponent<SpriteRenderer>().sprite = act2FireTrapPrepare;
                    }
                    else
                    {
                        t.GetComponent<SpriteRenderer>().sprite = act3FireTrapPrepare;
                    }
                }

                cycle++;
            }
            else if (cycle == 3)
            {
                // is on, causes burn
                //List<GameObject> mapTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Fire);
                foreach (GameObject t in FireTiles)
                {
                    if (GameManager.act == 1)
                    {
                        t.GetComponent<SpriteRenderer>().sprite = act2FireTrapOn;
                    }
                    else
                    {
                        t.GetComponent<SpriteRenderer>().sprite = act3FireTrapOn;
                    }
                }
                cycle++;
            }
            else if (cycle == 4)
            {
                // is off, causes burn
                //List<GameObject> mapTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Fire);
                foreach (GameObject t in FireTiles)
                {
                    if (GameManager.act == 1)
                    {
                        t.GetComponent<SpriteRenderer>().sprite = act2FireTrapOff;
                    }
                    else
                    {
                        t.GetComponent<SpriteRenderer>().sprite = act3FireTrapOff;
                    }
                }
                cycle++;
            }
            else if (cycle == 5)
            {
                cycle = 1;
            }
        }
        catch
        {
            // Does nothing
        }

        // Pickup
        if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Pickup)
        {
            var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
            int randomPickup;
            var fullHP = true;
            foreach(Character c in Party.party)
            {
                if(c.hp != c.maxhp)
                {
                    fullHP = false;
                    break;
                }
            }

            if(fullHP)
            {
                randomPickup = Random.Range(0, 2);
            }
            else
            {
                randomPickup = Random.Range(0, 3);
            }
            
            if(randomPickup == 0)
            {
                GameManager.money += 50;
                FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Cogs!");
            }
            else if (randomPickup == 1)
            {
                for (int i = 0; i < Party.party.Length; i++)
                {
                    Party.party[i].xp += 5;
                    while (Party.party[i].xp >= GameManager.XPtoLevel * Party.party[i].level)
                    {
                        Party.party[i].xp -= GameManager.XPtoLevel * Party.party[i].level;
                        Party.party[i].level++;
                        Party.party[i].maxhp += Party.party[i].hpmod;
                        Party.party[i].hp += Party.party[i].hpmod;
                    }
                }
                FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "XP!");
            }
            else
            {
                for (int i = 0; i < Party.party.Length; i++)
                {
                    Party.party[i].hp = Mathf.Min(Party.party[i].maxhp, Party.party[i].hp + 5);
                }
                FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Health!");
            }
            IsoGridGenerator.tilegrid[tile_x, tile_y] = IsoGridGenerator.Tiles.Blank;

            if(GameManager.act == 1)
            {
                t.GetComponent<SpriteRenderer>().sprite = act2BlankTile;
            }
            else if(GameManager.act == 2 || GameManager.act == 3)
            {
                t.GetComponent<SpriteRenderer>().sprite = act3BlankTile;
            }
            else
            {
                t.GetComponent<SpriteRenderer>().sprite = blankTile;
            }
            
        }

        // Lever
        else if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Lever)
        {
            // Should pull lever
            var a = IsoGridGenerator.objectgrid[tile_x, tile_y];
            GameManager.leverActivated = true;
            List<GameObject> mapTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Door);
            foreach (GameObject t in mapTiles)
            {
                Color objectColor = t.GetComponent<SpriteRenderer>().color;
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 255);
                t.GetComponent<SpriteRenderer>().color = objectColor;
            }

            if (GameManager.act == 1)
            {
                a.GetComponent<SpriteRenderer>().sprite = act2LeverOn;
            }
            else if (GameManager.act == 2 || GameManager.act == 3)
            {
                a.GetComponent<SpriteRenderer>().sprite = act3LeverOn;
            }
            else
            {
                a.GetComponent<SpriteRenderer>().sprite = leverOn;
            }  
        }

        // FireTrap
        else if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Fire)
        {
            var a = IsoGridGenerator.objectgrid[tile_x, tile_y];

            // Fire damage
            if (cycle == 4 || cycle == 5)
            {
                if (GameManager.fireTrapBurn)
                {
                    for (int i = 0; i < Party.party.Length; i++)
                    {
                        if(GameManager.act == 1)
                        {
                            Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 3);
                        }
                        else
                        {
                            Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 5);
                        }
                        
                    }
                    var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
                    FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Burn Damage!");
                }
                else
                {
                    GameManager.fireTrapBurn = true;
                    var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
                    FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Burn!");
                }
            }
        }

        // Trap
        else if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Trap)
        {
            for (int i = 0; i < Party.party.Length; i++)
            {
                if (GameManager.act == -1)
                {
                    Party.party[i].hp = Mathf.Max(10, Party.party[i].hp - 1);
                }
                else if (GameManager.act == 0)
                {
                    Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 3);
                }
                else if (GameManager.act == 1)
                {
                    Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 5);
                }
                else
                {
                    Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 7);
                }
            }
            var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
            FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Trap!");
        }

        

        // Exit tile
        if (tile_x == IsoGridGenerator.endLoc[0] && tile_y == IsoGridGenerator.endLoc[1])
        {
            if(GameManager.act != -1)
            {
                // Will load new level or whatever
                if (GameManager.floor == 8)
                {
                    GameManager.act++;
                    GameManager.floor = 1;
                }
                else
                {
                    GameManager.floor++;
                }
                SceneManager.LoadScene("Mission");
            }
            else
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
        else
        {
            var arr = FindObjectsOfType<EnemyGridMovement>();
            foreach (EnemyGridMovement enemy in arr)
            {

                bool adj = checkDist(enemy);
                bool same = sameDist(enemy);

                if (!adj)
                {
                    enemy.moveAction();
                    adj = checkDist(enemy);
                }

                if(same)
                {
                    for (int i = 0; i < Party.party.Length; i++)
                    {
                        Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 9);
                    }
                    var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
                    FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Trap!");
                }

                if (adj)
                {
                    if(enemy.party.Length > 0)
                    {
                        enterCombat = true;
                        Party.enemyParty = enemy.party;
                        triggeredEnemy = enemy.gameObject;
                        break;
                    }
                }

                
            }
        }

        bool checkDist(EnemyGridMovement enemy)
        {
            var xDist = Mathf.Abs(tile_x - enemy.tile_x);
            var yDist = Mathf.Abs(tile_y - enemy.tile_y);

            return (xDist <= 1 && yDist <= 1) && !(xDist == 1 && yDist == 1);
        }

        bool sameDist(EnemyGridMovement enemy)
        {
            var xDist = Mathf.Abs(tile_x - enemy.tile_x);
            var yDist = Mathf.Abs(tile_y - enemy.tile_y);

            return xDist == 0 && yDist == 0;
        }
    }

    /// <summary>
    /// Switches scene from Grid-mode to Combat-mode
    /// </summary>
    void EnterCombat()
    {
        if ((GameManager.floor == 8) || (GameManager.act == 3))
        {
            GameManager.leverActivated = true;
            List<GameObject> mapTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Door);
            foreach (GameObject t in mapTiles)
            {
                Color objectColor = t.GetComponent<SpriteRenderer>().color;
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 255);
                t.GetComponent<SpriteRenderer>().color = objectColor;
            }
        }

        if (TransitionManager.inMiddle==true)
        {
            enterCombat = false;
            GameManager.gm.combatManager.SetActive(true);
            var b = FindObjectOfType<BattleManager>();
            b.wingold = triggeredEnemy.GetComponent<EnemyGridMovement>().gold;
            b.winxp = triggeredEnemy.GetComponent<EnemyGridMovement>().xp;
            Destroy(triggeredEnemy);
            b.StartBattle();// insert a bool for transitions here
            GameManager.gm.isoGridManager.SetActive(false);
        }
        else
        {
            Invoke("EnterCombat", 0.0001f);
        }
      
    }


}
