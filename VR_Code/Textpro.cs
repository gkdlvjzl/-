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
        text.text = "�ȳ��ϼ��� ���� �����Դϴ�.".ToString();
    }
    void Hello_two()
    {
        text.text = "��ư�� ���� ���ø� �����ֽø� ������ ü���� �Ͻ� �� �ֽ��ϴ�.".ToString() +
            "���� �׽�Ʈ ���⼭ ����ħ".ToString() +
            "�� ����ħ    �̰� ���� �׽�Ʈ         �������".ToString();
    }
    void Hello_three()
    {
        text.text = "3��° �ؽ�Ʈâ ���⼭ ������ Ȯ�� ��ư ���� �׽�Ʈ ���� �� �ְ� �Ĺ� �ϰų� �ϴ� ������ ���⼭ ���� ��ġ�� �� ������� �� �� �� �� �� �� �� �� �� �� ī Ÿ �� ��";
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
