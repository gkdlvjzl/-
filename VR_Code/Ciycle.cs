using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Ciycle : MonoBehaviour
{
    [SerializeField] GameObject Particle;
    //[SerializeField] ParticleSystem Hove;

    AudioSource audios;

    private void Start()
    {
        //Hove = GetComponent<ParticleSystem>();
        this.audios = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ries"))
        {
            //Hove.Play();
            GameObject obj = Instantiate(Particle, Particle.transform.position, Quaternion.LookRotation(this.transform.up));

            Destroy(obj, 3f);
            OVRInput.SetControllerVibration(0.15f, 0.15f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.15f, 0.15f, OVRInput.Controller.LTouch);
            this.audios.Play();
        }
    }
}
