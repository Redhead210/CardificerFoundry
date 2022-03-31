/**
// File Name :         GameOverBehaviour.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Changes variables to zero upon death
**/
using UnityEngine;

public class GameOverBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.act = 0;
        GameManager.floor = 1;
    }

   
}
