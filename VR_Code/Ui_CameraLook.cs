using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_CameraLook : MonoBehaviour
{
    public Camera cameraToLookAt;
    public GameObject Panel;

    void Update()
    {
        float dir = Vector3.Distance(this.transform.position, cameraToLookAt.transform.position);

        if(dir < 1.5f)
        {
            Panel.SetActive(false);
        }
        else
            Panel.SetActive(true);

        transform.LookAt(transform.position + cameraToLookAt.transform.rotation * Vector3.forward,
         cameraToLookAt.transform.rotation * Vector3.up);
    }
}
