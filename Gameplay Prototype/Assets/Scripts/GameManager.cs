/**
// File Name :         GameManager.cs
// Author :            Will Bennington, Tyler Colander, Jason Czech, Sam Dwyer
// Creation Date :     October 2021
//
// Brief Description : Handles the majority of the heavy lifting of the game
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject isoGridManager;
    public GameObject combatManager;
    public static GameManager gm;

    public static int levelsToGold = 5;
    public static int XPtoLevel = 40;

    public static int characterBaseCost = 100;
    public static int characterLevelCost = 50;

    public GameObject ftPrefab;
    public GameObject hpbPrefab;
    public GameObject tgtPrefab;
    public GameObject atkPrefab;
    public GameObject actPrefab;
    public Sprite tempart;

    public Sprite bronzeFrame;
    public Sprite silverFrame;
    public Sprite genericCharacter;

    public Sprite[] characterEmblem;
    public Sprite[] characterBody;
    public Sprite[] characterHat;
    public Sprite characterHead;

    public static int act = 0;
    public static int floor = 1;
    public static bool leverActivated = false;
    public static bool loadSaveGame = false;

    public static bool inTutorialText = false;

    //money stuff
    public static int money = 0;

    public GameObject PauseMenu;
    public bool isPaused;

    public static float soundVolume = .5f;

    public AudioClip gridMusic;
    public AudioClip combatMusic;
    public AudioClip cardificerBattleTheme;
    public AudioSource managerAudioSource;
    public bool gridMusicIsNotPlaying;
    public bool combatMusicIsNotPlaying;
    public bool cardificerMusicNotPlaying;
    // if true, enter battle with burn
    public static bool fireTrapBurn = false;

    public static List<int> oldMaps = new List<int>();

    public static bool phase2 = false;
    public static bool inCardificerFight = false;
    public bool isInCardificer;

    // Start is called before the first frame update
    void Awake()
    {
        cardificerMusicNotPlaying = true;
        gridMusicIsNotPlaying = true;
        combatMusicIsNotPlaying = true;
        isPaused = false;
        gm = this;
        FloatingText.prefab = ftPrefab;
        managerAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isInCardificer = inCardificerFight;
        Time.timeScale = 1;
        // Reset old map list and reset floor to 1
        if(floor == 9)
        {
            oldMaps.Clear();
            floor = 1;
        }

        gameObject.GetComponent<AudioSource>().volume = soundVolume;

        if (SceneManager.GetActiveScene().name == "Mission")
        {
            if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                PauseMenu.SetActive(true);
                isPaused = true;
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                PauseMenu.SetActive(false);
                isPaused = false;
            }


            try
            {
                if (PauseMenu.activeInHierarchy == true)
                {
                    Time.timeScale = 0;
                }
            }
            catch
            {
                // bro
            }
            try
            {
                if (PauseMenu.activeInHierarchy == false)
                {
                    Time.timeScale = 1;
                }
            }
            catch
            {
                // bruh
            }

            try
            {

                if (isoGridManager.activeInHierarchy == true && gridMusicIsNotPlaying == true && inCardificerFight == false)
                {
                    managerAudioSource.clip = gridMusic;
                    managerAudioSource.Play();
                    gridMusicIsNotPlaying = false;
                    combatMusicIsNotPlaying = true;
                }
                if (combatManager.activeInHierarchy == true && combatMusicIsNotPlaying == true && inCardificerFight == false)
                {
                    managerAudioSource.clip = combatMusic;
                    managerAudioSource.Play();
                    combatMusicIsNotPlaying = false;
                    gridMusicIsNotPlaying = true;
                }
                if (cardificerBattleTheme == true && isoGridManager.activeInHierarchy == false && act == 3 && cardificerMusicNotPlaying == true)
                {
                    managerAudioSource.clip = cardificerBattleTheme;
                    managerAudioSource.Play();
                    cardificerMusicNotPlaying = false;
                    gridMusicIsNotPlaying = true;
                }
            }
            catch
            {
                // this is the last line of code i wrote - dwyer
            }
        }
        if(SceneManager.GetActiveScene().name == "Shop")
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                PauseMenu.SetActive(true);
                isPaused = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                PauseMenu.SetActive(false);
                isPaused = false;
            }

            if (PauseMenu.activeInHierarchy == true)
            {
                Time.timeScale = 0;
            }
            if (PauseMenu.activeInHierarchy == false)
            {
                Time.timeScale = 1;
            }
        }
    }
    
}
