using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokenStone : MonoBehaviour
{
    public GameObject Stones;

    AudioSource source;
    bool isDelay = false;

    private void Start()
    {        
        source = GetComponent<AudioSource>();
    }           
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("weapon") && !isDelay)
        {
            isDelay = true;
            source.Play();            
            Invoke("Destory_Stone", 0.5f);
        }
    }
    
    void Destory_Stone()
    {        
        gameObject.SetActive(false);
        Invoke("Create_Stone", 5f);
    }
    void Create_Stone()
    {
        gameObject.SetActive(true);
        isDelay = false;
    }
}
