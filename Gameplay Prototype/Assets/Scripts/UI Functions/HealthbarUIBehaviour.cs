/**
// File Name :         HealthbarUIBehaviour.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Makes sure the healthbars display the proper amounts
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUIBehaviour : MonoBehaviour
{
    public Slider hpb;
    Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = (int)hpb.value + "/" + hpb.maxValue;
    }
}
