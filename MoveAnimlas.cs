using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    [SerializeField] GameObject moveStart;
    [SerializeField] GameObject moveEnd;

    public int speed;
    public float retrunTime;
    public float TunSpeed;

    bool A = true;

    private void Start()
    {
        InvokeRepeating("Atrue", 2f, retrunTime);
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
            FollowTarget(moveStart);
            transform.position = Vector3.MoveTowards(transform.position, moveStart.transform.position, step);
        }
    }
    private void Loop2()
    {
        float EndCos = Vector3.Distance(transform.position, moveEnd.transform.position);

        float step = speed * Time.deltaTime;

        if (EndCos >= 1 && !A)
        {
            FollowTarget(moveEnd);
            transform.position = Vector3.MoveTowards(transform.position, moveEnd.transform.position, step);
        }
    }

    private void FollowTarget(GameObject STED)
    {
        if (STED != null)
        {
            Vector3 dir = STED.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * TunSpeed);
            // 맨뒤 스피드값 값에 따라 회전값조종가능
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
