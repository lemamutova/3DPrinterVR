using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    public Transform Red1, Red2, Yellow1, Yellow2, Cable, dir;
    Vector3 Red1_SP, Red2_SP, Yellow1_SP, Yellow2_SP, Mine_SP;
    public float scaleXmin, scaleXmax, scaleYmin, scaleYmax;

    public float dirXmin, dirXmax, extrZmin, extrZmax;


    // Start is called before the first frame update
    void Start()
    {
        Red1_SP = Red1.position;
        Red2_SP = Red2.position;
        Yellow1_SP = Yellow1.position;
        Yellow2_SP = Yellow2.position;
        Mine_SP = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float x = scaleXmin + ((scaleXmax - scaleXmin) * (dir.localPosition.x - dirXmin) / (dirXmax - dirXmin));
        float y = scaleYmin + ((scaleYmax - scaleYmin) * (transform.localPosition.z - extrZmin) / (extrZmax - extrZmin));
        Cable.localScale = new Vector3(x, y, 0.71f);
        if (Printer.state == Printer.State.Calibrate || Printer.state == Printer.State.Print)
        {
            Red1.position = Red1_SP + transform.position - Mine_SP;
            Red2.position = Red2_SP + transform.position - Mine_SP;
            Yellow1.position = Yellow1_SP + transform.position - Mine_SP;
            Yellow2.position = Yellow2_SP + transform.position - Mine_SP;
        }
    }
}
