using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Hover : MonoBehaviour
{
    [SerializeField] GameObject Fam_Ground;
    [SerializeField] ParticleSystem Hove;

    AudioSource audios;

    private void Start()
    {
        Hove = GetComponent<ParticleSystem>();
        this.audios = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Hove.Play();
            GameObject obj = Instantiate(Fam_Ground, this.transform.position, Quaternion.LookRotation(this.transform.forward));

            Destroy(obj, 3f);

            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
            this.audios.Play();
        }
    }
}
