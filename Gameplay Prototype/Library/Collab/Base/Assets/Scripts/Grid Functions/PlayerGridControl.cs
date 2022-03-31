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

    private bool startEndMap = false;

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
        if(startEndMap)
        {
            if(TransitionManager.inMiddle)
            {
                SceneManager.LoadScene("Mission");
                GameManager.floor++;
            }
        }

        pauseMenuActive = PauseMenu.activeInHierarchy;
        
       
        var moving = !transform.position.Equals(moveTowards);

        if (!moving)
        {
            if (enterCombat)
            {
                if (!IsInvoking("EnterCombat"))
                {
                    Invoke("EnterCombat",0.5f);
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
                    Invoke("moveAllEnemies", 1);
                }
                else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canMove(tile_x, tile_y - 1) && enemiesNotMoving == true && pauseMenuActive == false)
                {
                    bodySR.flipX = false;
                    headSR.flipX = false;
                    hatSR.flipX = false;
                    tile_y--;
                    enemiesNotMoving = false;
                    Invoke("moveAllEnemies", 1);
                }
                else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && canMove(tile_x - 1, tile_y) && enemiesNotMoving == true && pauseMenuActive == false)
                {
                    bodySR.flipX = false;
                    headSR.flipX = false;
                    hatSR.flipX = false;
                    tile_x--;
                    enemiesNotMoving = false;
                    Invoke("moveAllEnemies", 1);
                }
                else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && canMove(tile_x + 1, tile_y) && enemiesNotMoving == true && pauseMenuActive == false)
                {
                    bodySR.flipX = true;
                    headSR.flipX = true;
                    hatSR.flipX = true;
                    tile_x++;
                    enemiesNotMoving = false;
                    Invoke("moveAllEnemies", 1);
                }
                else if (Input.GetKeyDown(KeyCode.Space) && enemiesNotMoving == true && pauseMenuActive == false)
                {
                    moveAllEnemies();
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

        // Pickup
        if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Pickup)
        {
            IsoGridGenerator.tilegrid[tile_x, tile_y] = IsoGridGenerator.Tiles.Blank;
            var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
            t.GetComponent<SpriteRenderer>().sprite = blankTile;
        }

        // Lever
        else if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Lever)
        {
            // Should pull lever
            GameManager.leverActivated = true;
            List<GameObject> mapTiles = TileBehaviour.GetAllTileObjects(IsoGridGenerator.Tiles.Door);
            foreach (GameObject t in mapTiles)
            {
                Color objectColor = t.GetComponent<SpriteRenderer>().color;
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 255);
                t.GetComponent<SpriteRenderer>().color = objectColor;
            }
            var f = IsoGridGenerator.objectgrid[tile_x, tile_y];
            f.GetComponent<SpriteRenderer>().sprite = leverOn;
        }

        // Trap
        else if (IsoGridGenerator.tilegrid[tile_x, tile_y] == IsoGridGenerator.Tiles.Trap)
        {
            for(int i = 0; i < Party.party.Length; i++)
            {
                Party.party[i].hp = Mathf.Max(1, Party.party[i].hp - 5);
            }
            var t = IsoGridGenerator.objectgrid[tile_x, tile_y];
            FloatingText.Create(new Vector2(t.transform.position.x, t.transform.position.y + 2), "Trap!");
        }

        // Exit tile
        if (tile_x == IsoGridGenerator.endLoc[0] && tile_y == IsoGridGenerator.endLoc[1])
        {
            // Will load new level or whatever
            TransitionManager.TransitionDown();
            startEndMap = true;
        }
        else
        {
            var arr = FindObjectsOfType<EnemyGridMovement>();
            foreach (EnemyGridMovement enemy in arr)
            {

                bool adj = checkDist(enemy);

                if (!adj)
                {
                    enemy.moveAction();
                    adj = checkDist(enemy);
                }


                if (adj)
                {
                    enterCombat = true;
                    Party.enemyParty = EnemyArchetype.toCharacter(enemy.party);
                    triggeredEnemy = enemy.gameObject;
                    break;
                }

            }
        }

        bool checkDist(EnemyGridMovement enemy) {
            var xDist = Mathf.Abs(tile_x - enemy.tile_x);
            var yDist = Mathf.Abs(tile_y - enemy.tile_y);

            return (xDist <= 1 && yDist <= 1) && !(xDist == 1 && yDist == 1);
        }
    }

    /// <summary>
    /// Switches scene from Grid-mode to Combat-mode
    /// </summary>
    void EnterCombat()
    {
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
