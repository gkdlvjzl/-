using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimlas : MonoBehaviour
{
    [SerializeField] GameObject moveStart;
    [SerializeField] GameObject moveEnd;
    public int speed;

    bool A = true;

    private void Start()
    {
        InvokeRepeating("Atrue", 2f, 4f);
    }

    void Update()
    {
        Loop();
        Loop2();
    }     

    private void Loop()
    {
        float StartCos = Vector3.Distance(transform.position, moveStart.transform.position);

        float step = speed * Time.deltaTime;

        if (StartCos >= 1f && A)
        {
            transform.LookAt(moveStart.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, moveStart.transform.position, step);
        }   
    }
    private void Loop2()
    {
        float EndCos = Vector3.Distance(transform.position, moveEnd.transform.position);

        float step = speed * Time.deltaTime;

        if(EndCos >= 1 && !A)
        {
        transform.LookAt(moveEnd.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, moveEnd.transform.position, step);
        }
    }

    private void Atrue()
    {
        if (A)
        {
            A = false;
        }
        else
        {
            A = true;
        }
    }
}
