using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject isoGridManager;
    public GameObject combatManager;
    public static GameManager gm;

    public GameObject ftPrefab;
    public GameObject hpbPrefab;
    public GameObject tgtPrefab;
    public GameObject atkPrefab;
    public Sprite tempart;

    public Sprite bronzeFrame;
    public Sprite silverFrame;
    public Sprite genericCharacter;

    public Sprite[] characterBody;
    public Sprite[] characterHat;
    public Sprite characterHead;

    public static int act = 0;
    public static int floor = 2;
    public static bool leverActivated = false;

    //money stuff
    public static int money = 0;

    // Start is called before the first frame update
    void Awake()
    {
        gm = this;
        FloatingText.prefab = ftPrefab;
    }

    
}
