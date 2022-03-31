using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsoGridGenerator : MonoBehaviour
{
    public GameObject tileObject;
    public static Tiles[,] tilegrid;
    public static GameObject[,] objectgrid;
    public static int[] endLoc = new int[] { 0, 0 };

    public static List<Tiles[,]>[] levels;
    public static List<Tiles[,]>[] miniboss;
    public static List<Tiles[,]>[] floorboss;
    public static List<Tiles[,]>[] finalboss;

    public EnemyParty[] enemyParties1;
    public EnemyParty[] miniBosses1;
    public EnemyParty[] bosses1;

    public GameObject enemy;
    public static int startX, startY;
    public static int enemyX, enemyY;

    public EnemyParty outlaws;

    public enum Tiles { None, Blank, Trap, Enemy, Pickup, Lever, Door, Start, Exit, MBoss, ABoss, FBoss};

    private Tiles[,] grid = new Tiles[10, 10] ;

    private void Awake()
    {
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
        var f = Tiles.FBoss;

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
                               { p, b, b, b, b, t, b, b, b, x },
                               { s, b, b, b, t, b, b, b, b, p },
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
                               { p, b, n, n, n, n, n, n, b, x } } }

            // Difficult Maps

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

                new Tiles[,] { { n, n, b, b, b, b, b, n, n, n },
                               { n, b, b, b, b, b, b, b, n, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { s, b, b, b, f, b, b, b, b, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { b, b, b, b, b, b, b, b, b, n },
                               { n, b, b, b, b, b, b, b, n, n },
                               { n, n, b, b, p, b, b, n, n, n },
                               { n, n, n, n, n, n, n, n, n, n } } }
        };

        // Spawns shop
        if ( (GameManager.floor == 3) ||
            (GameManager.floor == 7) ||
            (GameManager.act == 3 && GameManager.floor == 1))
        {
            GameManager.floor++;
            SceneManager.LoadScene("Shop");
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

        // Spawns beginner map
        else if (GameManager.act == 0)
        {
            grid = GetMap(0);
        }

        // Spawns advanced map
        else if(GameManager.act == 1)
        {
            grid = GetMap(1);
        }

        // Spawns difficult map
        else if (GameManager.act == 2)
        {
            grid = GetMap(2);
        }

        // Generates the map
        GenerateGrid(grid, tileObject);
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

                    // If tile is a trap, gray
                    if(arr[i, i2] == Tiles.Trap)
                    {
                        t.GetComponent<Renderer>().material.color = Color.gray;
                    }

                    // If tile is the start, blue
                    else if (arr[i, i2] == Tiles.Start)
                    {
                        t.GetComponent<Renderer>().material.color = Color.blue;
                        startX = i;
                        startY = i2;
                    }

                    // If tile is a lever, magenta
                    else if (arr[i, i2] == Tiles.Lever)
                    {
                        t.GetComponent<Renderer>().material.color = Color.magenta;
                    }

                    // If tile is a door, yellow
                    else if (arr[i, i2] == Tiles.Pickup)
                    {
                        t.GetComponent<Renderer>().material.color = Color.yellow;
                    }

                    // If tile is exit, green
                    else if (arr[i, i2] == Tiles.Exit)
                    {
                        t.GetComponent<Renderer>().material.color = Color.green;
                        endLoc = new int[] { i, i2 };
                    }

                    // If tile is MBoss
                    else if (arr[i, i2] == Tiles.MBoss)
                    {
                        GetEnemy(miniBosses1).Create(i, i2);
                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is FBoss
                    else if (arr[i, i2] == Tiles.FBoss)
                    {
                        if (!((i + i2) % 2 == 0))
                        {
                            t.GetComponent<Renderer>().material.color = new Vector4(0.9f, 0.9f, 0.9f, 1f);
                        }
                    }

                    // If tile is ABoss
                    else if (arr[i, i2] == Tiles.ABoss)
                    {
                        GetEnemy(bosses1).Create(i, i2);
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
                        GetEnemy(enemyParties1).Create(i, i2);
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
        var r = levels[l][Random.Range(0, levels[l].Count)];
        return r;
    }

    // Gets map for the mini boss
    Tiles[,] GetMiniBossMap(int l)
    {
        var r = miniboss[l][0];
        return r;
    }

    // Gets map for the floor/act boss
    Tiles[,] GetFloorBossMap(int l)
    {
        var r = floorboss[l][0];
        return r;
    }

    // Gets final boss map
    Tiles[,] GetFinalBossMap(int l)
    {
        var r = finalboss[l][0];
        return r;
    }

    EnemyParty GetEnemy(EnemyParty[] l)
    {
        var r = Random.Range(0, l.Length);
        return l[r];
    }
}
