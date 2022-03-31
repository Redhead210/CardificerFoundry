/**
// File Name :         IsoGridGenerator.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Generates the map
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsoGridGenerator : MonoBehaviour
{
    public int genMapID = -1;

    public GameObject tileObject;
    public GameObject tileObject2;
    public GameObject tileObject3;
    public static Tiles[,] tilegrid;
    public static GameObject[,] objectgrid;
    public static int[] endLoc = new int[] { 0, 0 };

    public static List<Tiles[,]>[] levels;
    public static List<Tiles[,]>[] miniboss;
    public static List<Tiles[,]>[] floorboss;
    public static List<Tiles[,]>[] finalboss;
    public static List<Tiles[,]>[] tutorial;

    public EnemyParty[] tutorialEnemy;
    public EnemyParty[] enemyParties1;
    public EnemyParty[] miniBosses1;
    public EnemyParty[] bosses1;
    public EnemyParty[] enemyParties2;
    public EnemyParty[] miniBosses2;
    public EnemyParty[] bosses2;
    public EnemyParty[] saw;
    public EnemyParty[] enemyParties3;
    public EnemyParty[] miniBosses3;
    public EnemyParty[] bosses3;
    public EnemyParty[] cardificer;

    public GameObject enemy;
    public static int startX, startY;
    public static int enemyX, enemyY;

    public EnemyParty outlaws;

    public Sprite pickup;
    public Sprite trap;
    public Sprite leverOff;

    public Sprite act2tile;
    public Sprite act2pickup;
    public Sprite act2trap;
    public Sprite act2leverOff;
    public Sprite act2fireTrap;

    public Sprite act3tile;
    public Sprite act3pickup;
    public Sprite act3trap;
    public Sprite act3leverOff;
    public Sprite act3fireTrap;

    public enum Tiles { None, Blank, Trap, Fire, Saw, Enemy, Pickup, Lever, Door, Start, Exit, MBoss, ABoss, TutorialEnemy};

    private Tiles[,] grid = new Tiles[10, 10] ;

    private void Awake()
    {
        TransitionManager.TransitionUp();
        GameManager.leverActivated = false;
        var n = Tiles.None;
        var b = Tiles.Blank;
        var t = Tiles.Trap;
        var e = Tiles.Enemy;
        var p = Tiles.Pickup;
        var l = Tiles.Lever;
        var d = Tiles.Door;
        var s = Tiles.Start;
        var x = Tiles.Exit;
        var a = Tiles.ABoss;
        var m = Tiles.MBoss;
        var h = Tiles.Fire;
        var w = Tiles.Saw;
        var u = Tiles.TutorialEnemy;

        // Contains all the maps
        levels = new List<Tiles[,]>[] {

            // Beginner Maps
            new List<Tiles[,]> {


                new Tiles[,] { { b, n, n, n, n, n, n, n, b, e },
                               { b, b, n, n, n, n, n, b, p, b },
                               { s, b, b, n, n, n, b, b, b, b },
                               { b, b, b, b, n, b, b, e, b, b },
                               { b, b, b, b, d, b, b, b, b, b },
                               { b, b, e, b, d, b, b, b, b, b },
                               { b, b, b, b, n, b, b, b, b, t },
                               { b, t, b, n, n, n, b, b, e, x },
                               { b, b, n, n, n, n, n, b, b, t },
                               { l, n, n, n, n, n, n, n, b, b } } ,

                new Tiles[,] { { n, n, t, t, s, x, t, t, n, n },
                               { n, n, b, b, b, b, b, b, n, n },
                               { n, n, b, b, b, b, b, b, n, n },
                               { n, n, b, e, b, b, e, b, n, n },
                               { n, n, b, e, b, b, e, b, n, n },
                               { n, n, p, b, p, p, b, p, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n } } ,

                new Tiles[,] { { b, b, e, b, p, b, e, b, b, n },
                               { b, t, b, t, b, t, b, t, b, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { b, t, b, t, b, t, b, t, b, n },
                               { s, b, b, b, b, b, b, b, x, n },
                               { b, t, b, t, b, t, b, t, b, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { b, t, b, t, b, t, b, t, b, n },
                               { b, b, e, b, p, b, e, b, b, n },
                               { n, n, n, n, n, n, n, n, n, n } } ,

                new Tiles[,] { { s, n, n, n, n, b, b, p, n, x },
                               { b, b, b, b, d, b, d, b, d, b },
                               { l, n, n, b, n, b, n, b, n, b },
                               { d, n, n, b, n, b, n, b, n, b },
                               { p, n, n, b, n, b, n, b, n, b },
                               { e, n, n, b, n, b, n, b, n, b },
                               { b, n, n, b, n, b, n, b, n, b },
                               { e, n, n, b, n, b, n, b, n, b },
                               { b, p, n, b, b, b, n, b, n, b },
                               { e, b, n, n, n, n, n, b, b, b } } ,

                new Tiles[,] { { s, b, b, b, b, b, b, b, b, b },
                               { b, n, n, b, n, n, b, n, n, b },
                               { b, n, n, b, n, n, b, n, n, b },
                               { b, b, b, e, b, b, e, b, b, b },
                               { b, n, n, p, n, n, p, n, n, b },
                               { b, n, n, b, n, n, b, n, n, b },
                               { b, b, b, e, b, b, e, b, b, b },
                               { b, n, n, b, n, n, b, n, n, b },
                               { b, n, n, b, n, n, b, n, n, b },
                               { b, b, b, b, b, b, b, b, b, x } } ,

                new Tiles[,] { { n, b, b, n, n, n, n, b, b, n },
                               { b, b, b, b, b, e, b, b, b, b },
                               { s, b, b, b, b, b, b, b, b, b },
                               { n, b, b, n, n, n, n, p, b, n },
                               { n, b, b, n, n, n, n, p, e, n },
                               { n, b, b, n, n, n, n, p, b, n },
                               { b, b, b, b, b, b, b, b, b, b },
                               { b, b, b, b, b, e, b, b, b, x },
                               { n, b, b, n, n, n, n, b, b, n } } , 

                new Tiles[,] { { s, b, b, b, b, b, b, b, b, t },
                               { b, n, n, n, b, b, n, n, n, b },
                               { b, n, n, n, b, b, n, n, n, b },
                               { b, n, n, n, b, b, n, n, n, b },
                               { b, b, b, b, p, e, b, b, b, b },
                               { b, b, b, b, e, p, b, b, b, b },
                               { b, n, n, n, b, b, n, n, n, b },
                               { b, n, n, n, b, b, n, n, n, b },
                               { b, n, n, n, b, b, n, n, n, b },
                               { t, b, b, b, b, b, b, b, b, x } } ,

                new Tiles[,] { { b, b, b, b, b, b, p, b, b, b },
                               { b, b, b, b, n, b, b, b, e, b },
                               { b, b, b, n, n, n, b, b, b, b },
                               { b, b, n, n, n, n, n, b, b, b },
                               { s, n, n, n, n, n, n, n, b, x },
                               { b, b, n, n, n, n, n, b, b, b },
                               { b, b, b, n, n, n, b, b, b, b },
                               { b, b, b, b, n, b, b, b, e, b },
                               { b, b, b, b, b, b, p, b, b, b } }

            },

            // Advanced Maps

            new List<Tiles[,]> {

                new Tiles[,] { { n, n, n, n, e, e, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { p, b, b, b, b, h, b, b, b, x },
                               { s, b, b, b, h, b, b, b, b, p },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, e, e, n, n, n, n } } ,

                new Tiles[,] { { s, b, b, b, b, b, b, b, b, b },
                               { b, b, n, n, n, n, n, b, e, b },
                               { b, n, n, n, n, n, b, b, b, b },
                               { b, n, n, n, n, b, e, b, n, b },
                               { b, n, n, n, t, p, b, n, n, b },
                               { b, n, n, b, p, t, n, n, n, b },
                               { b, n, b, e, b, n, n, n, n, b },
                               { b, b, b, b, n, n, n, n, n, b },
                               { b, e, b, n, n, n, n, n, b, b },
                               { b, b, b, b, b, b, b, b, b, x } } ,

                new Tiles[,] { { s, b, n, n, n, n, n, n, e, p },
                               { b, b, b, n, n, n, n, b, b, b },
                               { n, b, b, b, n, n, b, b, b, n },
                               { n, n, b, b, b, b, b, b, n, n },
                               { n, n, n, b, t, b, b, n, n, n },
                               { n, n, n, b, b, t, b, n, n, n },
                               { n, n, b, b, b, b, b, e, n, n },
                               { n, b, b, b, n, n, b, b, b, n },
                               { e, b, b, n, n, n, n, b, b, b },
                               { p, b, n, n, n, n, n, n, b, x } } ,

                new Tiles[,] { { s, n, b, n, b, n, b, n, e, n },
                               { b, b, b, b, b, b, b, b, e, e },
                               { n, b, n, b, n, b, n, b, n, b },
                               { b, b, b, t, b, p, b, b, b, b },
                               { b, n, b, n, b, n, b, n, b, n },
                               { b, b, b, p, b, h, b, b, b, b },
                               { n, b, n, b, n, b, n, b, n, b },
                               { b, b, b, b, b, b, b, b, b, b },
                               { e, n, b, n, b, n, b, n, b, n },
                               { e, e, b, b, b, b, b, b, b, x } } ,

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { e, b, b, t, x, t, b, b, e, n },
                               { b, b, b, b, d, b, b, b, b, n },
                               { b, b, b, b, n, b, b, b, b, n },
                               { b, b, n, n, n, n, n, b, b, n },
                               { b, b, b, b, l, b, b, b, b, n },
                               { b, b, b, n, n, n, b, b, b, n },
                               { h, b, b, b, b, b, b, b, h, n },
                               { e, b, b, b, s, b, b, b, e, n },
                               { n, n, n, n, n, n, n, n, n, n } } ,

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { n, s, b, b, b, b, e, e, n, n },
                               { n, b, n, n, n, n, n, b, n, n },
                               { n, b, n, t, p, h, n, b, n, n },
                               { n, b, b, p, n, p, b, b, n, n },
                               { n, b, n, h, p, t, n, b, n, n },
                               { n, b, n, n, n, n, n, b, n, n },
                               { n, e, e, b, b, b, b, x, n, n },
                               { n, n, n, n, n, n, n, n, n, n } } ,

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { n, n, s, b, h, h, b, b, n, n },
                               { n, p, n, b, b, b, b, n, p, n },
                               { n, b, b, n, b, b, n, b, b, n },
                               { n, b, b, h, e, e, h, b, b, n },
                               { n, b, b, h, e, e, h, b, b, n },
                               { n, b, b, n, b, b, n, b, b, n },
                               { n, p, n, b, b, b, b, n, p, n },
                               { n, n, b, b, b, b, b, x, n, n },
                               { n, n, n, n, n, n, n, n, n, n } }
            },

            // Difficult Maps

            new List<Tiles[,]> {

                new Tiles[,] { { s, b, b, b, b, b, b, b, b, e },
                               { b, b, b, b, b, b, b, b, b, e },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, t, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, t, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { b, b, b, b, e, e, b, b, b, p },
                               { x, b, b, b, e, e, b, b, b, p } } ,

                new Tiles[,] { { b, b, b, b, b, p, b, b, b, p },
                               { s, b, b, b, e, b, b, b, b, e },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, b, b, n, n, n, n },
                               { n, n, n, n, e, e, n, n, n, n },
                               { n, n, n, n, e, x, n, n, n, n } } ,

                new Tiles[,] { { s, b, b, h, b, h, b, b, b, t },
                               { b, n, b, n, b, n, b, n, b, n },
                               { b, n, b, n, b, n, b, n, w, n },
                               { b, n, e, n, e, n, e, n, e, n },
                               { b, n, p, n, p, n, p, n, p, n },
                               { b, n, e, n, e, n, e, n, e, n },
                               { b, n, b, n, b, n, b, n, b, n },
                               { b, n, b, n, b, n, b, n, b, n },
                               { b, n, b, n, b, n, b, n, b, n },
                               { t, b, b, h, b, h, b, b, b, x } } ,

                new Tiles[,] { { s, b, b, b, b, b, b, b, b, e },
                               { b, b, n, n, n, b, h, b, b, b },
                               { n, n, n, b, t, b, b, b, b, b },
                               { n, b, b, b, b, h, b, e, t, b },
                               { n, b, h, b, b, t, b, b, b, b },
                               { b, b, b, b, e, b, n, n, n, d },
                               { b, t, b, b, h, b, n, p, h, b },
                               { b, b, b, e, b, b, n, h, b, b },
                               { n, b, l, h, b, b, n, b, e, b },
                               { n, n, n, n, t, p, n, x, b, b } } ,

                new Tiles[,] { { s, b, b, b, b, e, b, b, b, p },
                               { b, b, b, b, b, e, e, b, b, b },
                               { b, b, b, b, b, b, b, b, b, b },
                               { b, b, b, t, b, b, b, h, b, b },
                               { b, b, b, b, b, p, b, b, b, b },
                               { b, b, b, e, b, e, b, e, b, b },
                               { b, b, b, b, b, b, b, b, w, b },
                               { b, b, b, b, t, b, b, e, b, b },
                               { b, b, b, b, b, e, b, b, p, b },
                               { b, b, h, b, b, b, b, b, b, x } } ,

                new Tiles[,] { { s, b, n, n, n, n, n, n, n, n },
                               { b, b, e, b, n, n, n, n, n, n },
                               { b, b, b, b, b, b, n, n, n, n },
                               { p, b, b, h, b, b, e, b, n, n },
                               { b, e, b, b, b, p, b, t, b, e },
                               { b, b, b, e, b, b, h, b, b, x },
                               { b, b, b, b, t, e, b, b, n, n },
                               { b, b, b, b, b, b, n, n, n, n },
                               { e, e, b, b, n, n, n, n, n, n },
                               { p, p, n, n, n, n, n, n, n, n } } ,

                new Tiles[,] { { s, b, b, e, b, e, b, e, b, p },
                               { b, b, b, b, b, b, b, b, b, b },
                               { b, b, b, b, t, b, b, p, b, b },
                               { b, b, b, b, b, b, b, b, b, b },
                               { b, b, b, n, n, n, b, h, b, b },
                               { b, b, b, n, n, n, b, b, b, t },
                               { b, p, b, n, n, n, b, b, b, b },
                               { b, h, b, b, b, b, b, b, b, b },
                               { b, b, b, b, b, b, b, h, b, b },
                               { p, t, b, e, b, e, b, e, b, x } } ,

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { n, n, s, b, t, t, b, b, n, n },
                               { n, p, n, b, b, b, b, n, p, n },
                               { n, b, b, n, b, b, n, b, b, n },
                               { n, t, b, b, e, e, b, b, t, n },
                               { n, t, b, b, e, e, b, w, t, n },
                               { n, b, b, n, b, b, n, b, b, n },
                               { n, p, n, b, b, b, b, n, p, n },
                               { n, n, b, b, t, t, b, x, n, n },
                               { n, n, n, n, n, n, n, n, n, n } } ,

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { n, b, s, b, b, b, b, b, w, n },
                               { n, p, b, b, b, b, b, w, p, n },
                               { n, b, b, b, b, b, b, b, b, n },
                               { n, w, b, b, b, b, w, b, b, n },
                               { n, b, b, b, e, b, b, b, w, n },
                               { n, b, w, b, b, b, b, b, e, n },
                               { n, b, b, b, b, b, b, b, p, n },
                               { n, b, b, w, b, w, b, x, b, n },
                               { n, n, n, n, n, n, n, n, n, n } }
            },
        };

        // Map for the floor boss
        floorboss = new List<Tiles[,]>[] {

            new List<Tiles[,]> {

                new Tiles[,] { { n, n, n, b, b, b, n, n, n, n },
                               { n, n, b, b, b, b, b, n, n, n },
                               { n, b, b, b, b, b, b, b, n, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { s, b, b, b, a, b, b, b, d, x },
                               { b, b, b, b, b, b, b, b, b, n },
                               { n, b, b, b, b, b, b, b, n, n },
                               { n, n, b, b, b, b, b, n, n, n },
                               { n, n, n, b, p, b, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n } } }
        };

        // Map for the mini boss
        miniboss = new List<Tiles[,]>[] {

            new List<Tiles[,]> {

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, s, n, n, n, n, n },
                               { n, n, n, n, b, n, n, n, n, n },
                               { n, n, n, n, b, n, n, n, n, n },
                               { n, n, n, n, b, n, n, n, n, n },
                               { n, n, n, n, b, n, n, n, n, n },
                               { n, n, n, n, m, n, n, n, n, n },
                               { n, n, n, n, x, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n } } }
        };

        // Map for the final boss
        finalboss = new List<Tiles[,]>[] {

            new List<Tiles[,]> {

                new Tiles[,] { { n, n, b, b, s, b, b, n, n, n },
                               { n, b, h, b, b, b, h, b, n, n },
                               { b, h, b, h, b, h, b, h, b, n },
                               { b, b, h, b, b, b, h, b, b, n },
                               { b, b, b, b, a, b, b, b, b, n },
                               { b, b, h, b, b, b, h, b, b, n },
                               { b, h, b, h, b, h, b, h, b, n },
                               { n, b, h, b, b, b, h, b, n, n },
                               { n, n, b, b, d, b, b, n, n, n },
                               { n, n, n, n, x, n, n, n, n, n } } }
        };

        tutorial = new List<Tiles[,]>[] {

            new List<Tiles[,]> {

                new Tiles[,] { { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n },
                               { s, b, b, t, b, l, b, d, b, b },
                               { n, n, b, b, b, b, b, d, b, b },
                               { n, n, n, n, n, n, n, n, n, u },
                               { n, n, n, n, n, n, n, n, n, b },
                               { n, n, n, n, n, b, b, b, b, b },
                               { n, n, n, n, n, x, b, b, p, b },
                               { n, n, n, n, n, n, n, n, n, n } } }
        };

        if (!GameManager.loadSaveGame)
        {
            // Spawns shop
            if ((GameManager.floor == 3 && GameManager.act != 3) ||
                (GameManager.floor == 7) ||
                (GameManager.act == 3 && GameManager.floor == 1))
            {
                GameManager.floor++;
                SceneManager.LoadScene("Shop");
            }

            // Spawns tutorial map
            else if (GameManager.act == -1)
            {
                grid = GetTutorialMap(0);
            }

            // Spawns mini boss room
            else if (GameManager.floor == 4)
            {
                grid = GetMiniBossMap(0);
            }

            // Spawns floor boss room
            else if (GameManager.floor == 8)
            {
                grid = GetFloorBossMap(0);
            }

            // Spawns final boss room
            else if (GameManager.act == 3 && GameManager.floor == 2)
            {
                grid = GetFinalBossMap(0);
            }

            // Go to win screen
            else if (GameManager.act == 3 && GameManager.floor == 3)
            {
                GameManager.floor = 0;
                GameManager.act = 0;
                SceneManager.LoadScene("Win Screen");
            }

            // Spawns beginner map
            else if (GameManager.act == 0)
            {
                grid = GetMap(0);
            }

            // Spawns advanced map
            else if (GameManager.act == 1)
            {
                grid = GetMap(1);
            }

            // Spawns difficult map
            else if (GameManager.act == 2)
            {
                grid = GetMap(2);
            }
        }

        // Generates the map
        if(GameManager.act == 1)
        {
            GenerateGrid(grid, tileObject2);
        }
        else if(GameManager.act == 2 || GameManager.act == 3)
        {
            GenerateGrid(grid, tileObject3);
        }
        else
        {
            GenerateGrid(grid, tileObject);
        }
        tilegrid = grid;
    }

    /// <summary>
    /// Creates an isometric grid of gameObjects
    /// </summary>
    /// <param name="arr">Array to read from</param>
    /// <param name="go">gameObject to place (must have TileBehaviour)</param>
    public void GenerateGrid(Tiles[,] arr, GameObject go)
    {
        objectgrid = new GameObject[arr.Length, arr.Length];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int i2 = 0; i2 < arr.GetLength(1); i2++)
            {
                if (arr[i, i2] != Tiles.None) {
                    var f_x = transform.position.x;
                    var f_y = transform.position.y;



                    f_x += (i*2)+(i2*2);
                    f_y += i - i2;


                    var t = Instantiate(go, new Vector3(f_x, f_y, f_y), Quaternion.identity);

                    objectgrid[i, i2] = t;

                    var b = t.GetComponent<TileBehaviour>();
                    b.tile_x = i;
                    b.tile_y = i2;



                    // If tile is a trap
                    if(arr[i, i2] == Tiles.Trap)
                    {
                        if(GameManager.act == 1)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act2trap;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else if (GameManager.act == 2 || GameManager.act == 3)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act3trap;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else
                        {
                            t.GetComponent<SpriteRenderer>().sprite = trap;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                    }

                    // If tile is a firetrap
                    else if (arr[i, i2] == Tiles.Fire)
                    {
                        if (GameManager.act == 1)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act2fireTrap;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act3fireTrap;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                    }

                    // If tile is the start
                    else if (arr[i, i2] == Tiles.Start)
                    {
                        startX = i;
                        startY = i2;
                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is a saw trap
                    else if(arr[i, i2] == Tiles.Saw)
                    {
                        GetEnemy(saw).Create(i, i2);
                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is a lever
                    else if (arr[i, i2] == Tiles.Lever)
                    {
                        if (GameManager.act == 1)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act2leverOff;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else if (GameManager.act == 2 || GameManager.act == 3)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act3leverOff;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else
                        {
                            t.GetComponent<SpriteRenderer>().sprite = leverOff;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                    }

                    // If tile is a door
                    else if (arr[i, i2] == Tiles.Pickup)
                    {
                        if (GameManager.act == 1)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act2pickup;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else if (GameManager.act == 2 || GameManager.act == 3)
                        {
                            t.GetComponent<SpriteRenderer>().sprite = act3pickup;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                        else
                        {
                            t.GetComponent<SpriteRenderer>().sprite = pickup;
                            if (!((i + i2) % 2 == 0))
                            {
                                t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                            }
                        }
                    }

                    // If tile is exit
                    else if (arr[i, i2] == Tiles.Exit)
                    {
                        t.GetComponent<Renderer>().material.color = Color.green;
                        endLoc = new int[] { i, i2 };
                    }

                    // If tile is MBoss
                    else if (arr[i, i2] == Tiles.MBoss)
                    {
                        // Act 1
                        if(GameManager.act == 0)
                        {
                            GetEnemy(miniBosses1).Create(i, i2);
                        }
                        // Act 2
                        else if(GameManager.act == 1)
                        {
                            GetEnemy(miniBosses2).Create(i, i2);
                        }
                        // Act 3
                        else
                        {
                            GetEnemy(miniBosses3).Create(i, i2);
                        }

                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is ABoss
                    else if (arr[i, i2] == Tiles.ABoss)
                    {
                        // Act 1
                        if (GameManager.act == 0)
                        {
                            GetEnemy(bosses1).Create(i, i2);
                        }
                        // Act 2
                        else if (GameManager.act == 1)
                        {
                            GetEnemy(bosses2).Create(i, i2);
                        }
                        // Act 3
                        else if (GameManager.act == 2)
                        {
                            GetEnemy(bosses3).Create(i, i2);
                        }
                        // Act 4 || FINAL BOSS
                        else
                        {
                            GetEnemy(cardificer).Create(i, i2);
                        }

                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is Door
                    else if (arr[i, i2] == Tiles.Door)
                    {
                        Color objectColor = t.GetComponent<SpriteRenderer>().color;
                        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 0);
                        t.GetComponent<SpriteRenderer>().color = objectColor;
                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is Enemy
                    else if (arr[i, i2] == Tiles.Enemy)
                    {
                        // Act 1
                        if (GameManager.act == 0)
                        {
                            GetEnemy(enemyParties1).Create(i, i2);
                        }
                        // Act 2
                        else if (GameManager.act == 1)
                        {
                            GetEnemy(enemyParties2).Create(i, i2);
                        }
                        // Act 3
                        else
                        {
                            GetEnemy(enemyParties3).Create(i, i2);
                        }

                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is TutorialEnemy
                    else if (arr[i, i2] == Tiles.TutorialEnemy)
                    {
                        GetEnemy(tutorialEnemy).Create(i, i2);
                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    else if (!((i+i2)%2==0))
                    {
                        t.GetComponent<Renderer>().material.color = new Vector4(0.9f,0.9f,0.9f,1f);
                    }

                    t.transform.parent = transform;
                }
            }
        }

        foreach (TileBehaviour t in FindObjectsOfType<TileBehaviour>())
        {
            if (t.tile_x == endLoc[0]&&t.tile_y == endLoc[1])
            {
                t.GetComponent<Renderer>().material.color = Color.green;
                break;
            }
        }
    }

    // Gets random map
    Tiles[,] GetMap(int l)
    {
        int i;

        // Makes sure the ap isnt one that have been seen
        do
        {
            i = Random.Range(0, levels[l].Count);            
        }
        // Checks to see if map is contained in list of old maps
        while (GameManager.oldMaps.Contains(i));

        // Adds map to list of previous maps
        GameManager.oldMaps.Add(i);

        //Saves map's ID
        genMapID = i;

        var r = levels[l][i];
        // Returns random map
        return r;
    }

    // Gets map for the mini boss
    Tiles[,] GetMiniBossMap(int l)
    {
        var r = miniboss[l][0];
        genMapID = 0;
        return r;
    }

    // Gets map for the floor/act boss
    Tiles[,] GetFloorBossMap(int l)
    {
        var r = floorboss[l][0];
        genMapID = 0;
        return r;
    }

    // Gets final boss map
    Tiles[,] GetFinalBossMap(int l)
    {
        var r = finalboss[l][0];
        genMapID = 0;
        return r;
    }

    // Gets map for the tutorial
    Tiles[,] GetTutorialMap(int l)
    {
        var r = tutorial[l][0];
        genMapID = 0;
        return r;
    }

    Tiles[,] GetMapWithID(int id, int act)
    {
        return levels[act][id];
    }

    EnemyParty GetEnemy(EnemyParty[] l)
    {
        var r = Random.Range(0, l.Length);
        return l[r];
    }
}
