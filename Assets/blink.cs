using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blink : MonoBehaviour
{
    float t;
    public void Start()
    {
        t = 0f;
    }
    public void Update()
    {
        if (t > 1) reverse = true;
        if (t < 0) reverse = false;
        t = reverse ? t - Time.deltaTime * 1.5f : t + Time.deltaTime * 1.5f;
        Color C = 
        this.GetComponent<Renderer>().material.color = Color.Lerp(new Color(0.5f, 0.5f, 0f, 0.05f), new Color(0.5f, 0.5f, 0f, 0.1f), t);
        //float x = 0.1f + t/50;
        //transform.localScale = new Vector3(x,x,x);
    }

    bool reverse;

}
