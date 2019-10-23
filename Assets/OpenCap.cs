using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCap : MonoBehaviour, IPointerClickHandler
{
    public Animator A;
    public string type;

    public void Start()
    {

    }

    public void OnPointerClick(PointerEventData ped)
    {
        A.SetTrigger(type);
        /*if (type == "open" || type == "bobina_red")
        {
            this.GetComponent<emissionBlink>().enabled = false;
            this.GetComponent<Renderer>().material.SetBool("_EmissionColor", Color.black);
        }*/
        if (type == "print")
        {
            Printer.state = Printer.State.Print;
        }
        if (type == "calibrate") Printer.state = Printer.State.Calibrate;
    }

    public void OnDisabled()
    {

    }
}
