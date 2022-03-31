/**
// File Name :         FloatingText.cs
// Author :            Jason Czech
// Creation Date :     October 2021
//
// Brief Description : Allows for text to pop up and fade away
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    static int fadeSpeed = 10;
    static int floatSpeed = 15;
    static float fadeTime = 1f;
    public static GameObject prefab;
    bool fading = false;

    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        Invoke("StartFading", fadeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (floatSpeed * Time.deltaTime));

        if (fading)
        {
            txt.color = Color.Lerp(txt.color, new Color(1, 1, 1, 0), fadeSpeed * Time.deltaTime);
            if (txt.color.a < 0.01f)
            {
                Destroy(gameObject);
            }
        }

        transform.SetAsLastSibling();
    }

    void StartFading()
    {
        fading = true;
    }

    public static GameObject Create(Vector2 pos, string txt, bool worldPos = false)
    {
        if (!worldPos)
        {
            pos = Camera.main.WorldToScreenPoint(pos);
        }

        var o = Instantiate(FloatingText.prefab,pos,Quaternion.identity,FindObjectOfType<Canvas>().transform);
        o.GetComponent<Text>().text = txt;
        return o;
    }
}
