using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchSotne : MonoBehaviour
{
    public GameObject[] Stones;

    AudioSource source;
    public AudioSource source1;

    int i;
    int j;

    bool isDelay = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();        
        i = Stones.Length;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon") && !isDelay)
        {
            if (j < i)
        {
            source.Play();
            Stones[j].gameObject.SetActive(false);
            j++;
        }
            else
        {
            isDelay = true;            
            Invoke("Create_Stone", 5f);
        }
        }
    }
    void Create_Stone()
    {
        for(int k = 0; k < Stones.Length; k++)
        {
            Stones[k].gameObject.SetActive(true);
        }
        j = 0;
            source1.Play();
        isDelay = false;
    }
}
