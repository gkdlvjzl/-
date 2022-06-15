using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruu : MonoBehaviour
{
    public GameObject[] movePoint;
    public int Lastsize;

    [SerializeField] int index;
    [SerializeField] float speed;


    void Update()
    {
        if (index >= Lastsize)
        {
            Destroy(gameObject);
        }
        else
        {
            Loop();
        }

    }
    private void Loop()
    {             
        float nextCos = Vector3.Distance(transform.position, movePoint[index].transform.position);
        
        float step = speed * Time.deltaTime;
        if (nextCos < 0.5f && movePoint != null)
        {
            index++;
        }
        else
        {
        transform.LookAt(movePoint[index].transform.position);
        transform.position = Vector3.Lerp(transform.position, movePoint[index].transform.position, step);

        //Vector3.Lerp or movetowards중 lerp 첫스타트가 부드럽게 출발하는데 이걸로 조정해야할까?
        }
    }
}