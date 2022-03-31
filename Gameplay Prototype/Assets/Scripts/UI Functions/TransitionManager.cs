/**
// File Name :         TransitionManager.cs
// Author :            Will Bennington, Jason Czech, Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Handles the transitions between the battle and the map screens
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    static float movementSpeed = 2000;
    public float screenHeight = Screen.height;
    static public RectTransform RT;
    public static bool moveUp;
    public static bool moveDown;
    public static bool inMiddle;

    private void Start()
    {
        RT = GetComponent<RectTransform>();
        moveUp = true;
    }

    private void Update()
    {
        if (RT.transform.position.y<= 700&&RT.transform.position.y>=550) 
        {
           inMiddle = true;
            
        }
        else
        {
            inMiddle = false;
        }

        if (moveUp == true)
        {
            Vector3 aPos = RT.transform.position;
            aPos.x = aPos.z = 0;
            aPos.y = movementSpeed * Time.deltaTime;
            RT.transform.position += aPos;

        }

        if(RT.transform.position.y>=Screen.height*2)
        {
            moveUp = false;
        }

        if (moveDown==true)
        {
            Vector3 aPos = RT.transform.position;
            aPos.x = aPos.z = 0;
            aPos.y = movementSpeed * Time.deltaTime;
            RT.transform.position -= aPos;
        }

        if(RT.transform.position.y<=-(screenHeight *2))
        {
            moveDown = false;
        }

        transform.SetAsLastSibling();
    }

   public static void TransitionUp()
    {
        moveDown = false;
        moveUp = true;
        
    }

    public static void TransitionDown()
    {
        moveUp = false;
        moveDown = true;
    }

    void Stuttermovement()
    {
        bool shouldMove=true;

        if(shouldMove==true)
        {
            movementSpeed = 2000;
            shouldMove = false;
        }
        else if(shouldMove==false)
        {
            movementSpeed = 0;
        }
    }
}

   

