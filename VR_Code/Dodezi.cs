using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodezi : MonoBehaviour
{
    Transform here;

    public float speed;
    public float moveTime;

    int moveslot;

    float movepoint = 0.4f;

    void Start()
    {
        here = GetComponent<Transform>();
    }

    void Update()
    {
        move();
    }

    void UpTime()
    {

    }

    void move()
    {
        float step = speed * Time.deltaTime;

        float moveaf = Vector3.Distance(transform.position, here.transform.position);

        transform.position = Vector3.MoveTowards(here.position, new Vector3(Random.Range(-movepoint, movepoint), here.position.y, Random.Range(-movepoint, movepoint)),step);
    }
}
