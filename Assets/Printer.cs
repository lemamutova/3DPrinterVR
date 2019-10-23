using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public GameObject Model;

    public enum State
    {
        StandBy,
        Open,
        Bobina_load,
        BobinaRed_loading,
        BobinaYellow_loading,
        Plastic_Cahrge,
        Calibrate,
        Print
    }

    public static State state;

    public void SetPrintState()
    {
        state = State.Calibrate;


    }

    public void SetUnprintState()
    {
        state = State.StandBy;
    }

    public void SetvisibleModel()
    {
        Model.SetActive(true);
    }
    public void SetInvisibleModel()
    {
        Model.SetActive(false);
    }
    public void Update()
    {
        
    }
}
