using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    Vector3 MyStartPosition;
    Quaternion MyStartRotation;
    Vector3 StartGlobalPos;
    Quaternion StartGlobalRot;
    Transform parent;
    public Transform Hand;
    // Start is called before the first frame update
    void Start()
    {
        MyStartPosition = transform.localPosition;
        parent = transform.parent;
        MyStartRotation = transform.localRotation;
        StartGlobalPos = transform.position;
        StartGlobalRot = transform.rotation;
    }

    // Update is called once per frame
    
    public void Grab()
    {
        Debug.Log("Enter");
        if (!_Grab)
        {
            _Grab = true;
            Debug.Log("grab");
            
            StartGlobalPos = transform.position;
        }
        

    }

    public void UnGrab()
    {
        //Debug.Log("ungrab");
        if(!ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
        {
            _Grab = false;
            Debug.Log("ungrab");
        }
        
    }

    bool grabbed;

    /*Coroutine GTM;

    IEnumerator GrabtoMe(bool reverse = false)
    {
        float t = 0f;

        Vector3 StartGlobalPos = transform.position;
        Quaternion StartGlobalRot = transform.rotation;

        while (t<1)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(StartGlobalPos, Hand.position, t);
            transform.rotation = Quaternion.Lerp(StartGlobalRot, Hand.rotation, t);
            yield return null;
        }
        transform.parent = Hand;
    }*/

    bool resetted;
    public void Reset()
    {
        resetted = true;
        Debug.Log("reset");
        transform.parent = parent;
        transform.localPosition = MyStartPosition;
        transform.localRotation = MyStartRotation;
        //gameObject.SetActive(false);
    }

    public void HideMe()
    {
        gameObject.SetActive(false);
    }
    public bool _Grab;
    bool fly;
    public float t;
    public void Update()
    {
        if (_Grab && ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
        {

            if (transform.parent != null)
            {
                transform.parent = null;
                StartGlobalRot = transform.rotation;
                StartGlobalPos = transform.position;
            }
            
            t += Time.deltaTime;
            resetted = false;
        }
        else
        {
            t -= Time.deltaTime;
            if (!resetted && t < 0) Reset();
        }
        t = Mathf.Clamp(t, 0f, 1f);
        fly = (t != 0);
        if (fly)
        {
            transform.position = Vector3.Lerp(StartGlobalPos, Hand.position, t);
            transform.rotation = Quaternion.Lerp(StartGlobalRot, Hand.rotation, t);
        }
    }

}
