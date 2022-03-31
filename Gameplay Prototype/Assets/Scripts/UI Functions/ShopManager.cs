/**
// File Name :         ShopManager.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Handles the traversal of the shop
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Button ShopBtn;
    public Button PartyBtn;

    public GameObject PartyUIPrefab;
    public GameObject ShopUI;

    // Start is called before the first frame update
    void Start()
    {
        if (ShopBtn != null)
        {
            ShopBtn.onClick.AddListener(SwitchToShop);
        }
        if (PartyBtn != null)
        {
            PartyBtn.onClick.AddListener(SwitchToParty);
        }
        
    }

    public void SwitchToParty()
    {
        if (GameObject.Find("DeckSwap(Clone)") == null)
        {
            ShopUI.SetActive(false);
            Instantiate(PartyUIPrefab);
        } 
    }

    public void SwitchToShop()
    {
        if (!ShopUI.activeSelf)
        {
            Destroy(GameObject.Find("DeckSwap(Clone)"));

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ShopUI"))
            {
                Destroy(obj);
            }

            ShopUI.SetActive(true);
        }
    }
}
