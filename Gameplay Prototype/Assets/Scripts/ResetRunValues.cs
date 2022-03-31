
/**
// File Name :         ResetRunValues.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Makes sure that all the values at the begin of each run are correct
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRunValues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.act = 0;
        GameManager.floor = 1;
        GameManager.money = 0;
        GameManager.leverActivated = false;
        GameManager.inTutorialText = false;
        GameManager.fireTrapBurn = false;
        GameManager.oldMaps.Clear();
        GameManager.inCardificerFight = false;
    }
}
