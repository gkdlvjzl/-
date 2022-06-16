using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDestroy : MonoBehaviour
{
    public GameObject[] movePoint;
    public int Lastsize;

    [SerializeField] int index;
    [SerializeField] float speed;
    [SerializeField] float TunSpeed;


    void Update()
    {
        if (index >= Lastsize)
        {
            Destroy(gameObject);
        }
        else
        {            
            FollowTarget();
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
            //transform.LookAt(movePoint[index].transform.position); 바로 회전 / 바라보는 코드 밑 Quaternion.Lerp 사용으로 인해 주석처리
            transform.position = Vector3.Lerp(transform.position, movePoint[index].transform.position, step);

        //Vector3.Lerp or movetowards중 lerp 첫스타트가 부드럽게 출발하는데 이걸로 조정해야할까?
        }
    }

    void FollowTarget()
    {
        if (movePoint != null)
        {
            Vector3 dir = movePoint[index].transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * TunSpeed);
            // 맨뒤 스피드값 값에 따라 회전값조종가능
        }
    }
}
