using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [Range(1f, 100f)]
    public float ScaleSpeed = 1f;
    Vector3 StartScale;
    // Start is called before the first frame update
    void Start()
    {
        StartScale = transform.localScale;
    }

    public bool captured;

    public void Capture()
    {
        previous = GetY();
        captured = true;
        //Debug.Log("captured");
        
    }

    public void UnCapture()
    {
        captured = false;
        //Debug.Log("uncaptured");
    }

    float previous;
    float scaleFactor;

    // Update is called once per frame
    void Update()
    {
        if(captured && ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
        {
            //Debug.Log("Its mine! " + gameObject.name + captured);
            scaleFactor = Mathf.Clamp(scaleFactor + (GetY() - previous) * ScaleSpeed, 1f, 2.5f);
            previous = GetY();
            //Debug.Log(scaleFactor);
            transform.localScale = scaleFactor * StartScale;
        }

        
        
    }
    float GetY()
    {
        return ViveInput.GetAxisEx(HandRole.RightHand, ControllerAxis.PadY);
    }
}
