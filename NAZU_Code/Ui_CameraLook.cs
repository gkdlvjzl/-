using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_CameraLook : MonoBehaviour
{
    public Camera cameraToLookAt;

    void Update()
    {
        transform.LookAt(transform.position + cameraToLookAt.transform.rotation * Vector3.forward,
         cameraToLookAt.transform.rotation * Vector3.up);
    }
}
