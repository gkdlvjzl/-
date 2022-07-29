
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectlaser : MonoBehaviour
{
    [SerializeField] Transform Player_Hend;
    [SerializeField] GameObject Object;

    private void Start()
    {
        hendType();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(Object.transform.position, Player_Hend.position, 0.15f);
        Invoke("hendType", 0.5f);
    }
    public void in_object()
    {
        gameObject.GetComponent<Objectlaser>().enabled = true;        
    }

    void hendType()
    {
        gameObject.GetComponent<Objectlaser>().enabled = false;
    }

}
