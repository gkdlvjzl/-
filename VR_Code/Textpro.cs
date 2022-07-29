using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Textpro : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    int i;

    private void Start()
    {
        gameObject.SetActive(false);
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (i.Equals(0))
        {
            Hello_frist();
        }
        if (i.Equals(1))
        {
            Hello_two();
        }
        if (i.Equals(2))
        {
            Hello_three();
        }
        if (i >= 3)
        {
            gameObject.SetActive(false);
        }
    }

    void Hello_frist()
    {
        text.text = "안녕하세요 여긴 농장입니다.".ToString();
    }
    void Hello_two()
    {
        text.text = "버튼을 눌러 지시를 따라주시면 간단한 체험을 하실 수 있습니다.".ToString() +
            "엔터 테스트 여기서 엔터침".ToString() +
            "또 엔터침    이건 공백 테스트         여기까지".ToString();
    }
    void Hello_three()
    {
        text.text = "3번째 텍스트창 여기서 마지막 확인 버튼 이후 테스트 실행 물 주고 파밍 하거나 일단 구상은 여기서 엔터 안치고 쭉 적어보았음 가 나 다 라 마 바 사 아 자 차 카 타 파 하";
    }
    public void click_next()
    {
        i++;
        StartCoroutine(Stopclick());
    }
    IEnumerator Stopclick()
    {
        yield return null;
    }
}
