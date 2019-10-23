using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emissionBlink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float t;
    public Color C;
    // Update is called once per frame
    void Update()
    {
        if (t > 1) reverse = true;
        if (t < 0) reverse = false;
        t = reverse ? t - Time.deltaTime * 1.5f : t + Time.deltaTime * 1.5f;
        C = Color.Lerp(new Color(0.1f, 0.1f, 0f, 1f), new Color(0.3f, 0.3f, 0f, 1f), t);
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", C);
        
    }

    bool reverse;

    public void OnDisable()
    {
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }
}
