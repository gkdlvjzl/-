using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Transform[] movePoint;
    [SerializeField] float speed;

    public float ReTurnTime;
    int moveNum = 0;

    private void Start()
    {
        transform.position = movePoint[moveNum].position;
    }
    private void Update()
    {
        Path();
    }

    void Path()
    {
        float step = speed * Time.deltaTime;
        float nextPoint = Vector3.Distance(transform.position, movePoint[moveNum].position);
        
            FollowTarget(movePoint[moveNum]);
            transform.position = Vector3.MoveTowards(transform.position, movePoint[moveNum].transform.position, step);        

        if(nextPoint < 0.01f)
            moveNum++;

        if (moveNum == movePoint.Length)
            moveNum = 0;
    }
    private void FollowTarget(Transform STED)
    {
        if (STED != null)
        {
            Vector3 dir = STED.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * ReTurnTime);
            // 맨뒤 스피드값 값에 따라 회전값조종가능
        }
    }
}
