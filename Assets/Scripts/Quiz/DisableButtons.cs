using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtons : MonoBehaviour
{

    public Button a, b, c, d;

    public void resetButtons()
    {
        a.interactable = true;
        b.interactable = true;
        c.interactable = true;
        d.interactable = true;
    }
    public void butttonA()
    {
        b.interactable = false ;
        c.interactable = false;
        d.interactable = false;

    }
    public void butttonB()
    {
        a.interactable = false;
        c.interactable = false;
        d.interactable = false;
    }
    public void butttonC()
    {
        a.interactable = false;
        b.interactable = false;
        d.interactable = false;
    }
    public void butttonD()
    {
        a.interactable = false;
        b.interactable = false;
        c.interactable = false;
    }
}
