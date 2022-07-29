using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_Text : MonoBehaviour
{
    public TMP_Text text;

    public int Wood_count = 0;
    public int Stone_count = 0;

    bool isPlay;
    public GameObject Tmt;

    void Start()
    {
        text = GetComponent<TMP_Text>();        
    }

    void Update()
    {
        float dir = Vector3.Distance(this.transform.position, Tmt.transform.position);

        if (dir < 1.5f && isPlay)
        {
            Join();       
        }
    }

    void Join()
    {
        StartCoroutine(Join_text());
    }
    readonly WaitForSeconds Wait6f = new WaitForSeconds(6f);
    IEnumerator Join_text()
    {        
        text.text = "건설기능을 알려드리겠습니다 불랴불랴".ToString();
        text.color = Color.red;
        text.text = "건설에 필요한 자원은".ToString() + (Wood_count) + "의 필요 나무와".ToString()
            + (Stone_count) + "의 필요 돌량입니다.".ToString();
        yield return Wait6f;
        isPlay = false;
        //isPlay = true;
    }
}
