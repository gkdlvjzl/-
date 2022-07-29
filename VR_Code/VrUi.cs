using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrUi : MonoBehaviour
{
    public GameObject Stats;
    //public GameObject TestMenu;

    public void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            On();
        }
        else
        {
            Off();
        }
    }
    public void On()
    {
        Stats.SetActive(true);
    }

    void Off()
    {
        Stats.SetActive(false);
    }
}
