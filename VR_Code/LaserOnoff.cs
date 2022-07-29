using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOnoff : MonoBehaviour
{
    [SerializeField] GameObject Object;

    public OVRInput.Button Button_Num;

    private void Update()
    {
        if (OVRInput.Get(Button_Num))
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
        Object.SetActive(true);
    }

    void Off()
    {
        Object.SetActive(false);
    }

}
