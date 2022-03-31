/**
// File Name :         Tools.cs
// Author :            Jason Czech
// Creation Date :     October, 2021
//
// Brief Description : Tools specifcially made for this project
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Tools
{
    public static int Wrap(int i, int bottom, int top)
    {
        var s = top - bottom;

        while (i > top)
        {
            i -= s-1;
        }

        while (i < bottom)
        {
            i += s-1;
        }

        return i;
    }

    public static float MoveTowards(float i, float dest, float amount)
    {
        if (i == dest)
        {
            return i;
        }

        if (dest-i > 0)
        {
            return Mathf.Max(dest, i + amount);
        }

        return Mathf.Min(dest, i - amount);
    }

   }
