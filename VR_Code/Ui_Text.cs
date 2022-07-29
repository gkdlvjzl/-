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
        text.text = "�Ǽ������ �˷��帮�ڽ��ϴ� �ҷ��ҷ�".ToString();
        text.color = Color.red;
        text.text = "�Ǽ��� �ʿ��� �ڿ���".ToString() + (Wood_count) + "�� �ʿ� ������".ToString()
            + (Stone_count) + "�� �ʿ� �����Դϴ�.".ToString();
        yield return Wait6f;
        isPlay = false;
        //isPlay = true;
    }
}
