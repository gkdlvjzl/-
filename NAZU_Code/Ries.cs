using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ries : MonoBehaviour
{
    public GameObject objectToScale;
    public float Up_Speed;
    public Vector3 minsize;
    public Vector3 maxsize;
    public Coroutine scaleCoroutine;


    private void Start()
    {
        objectToScale.transform.localScale = minsize;
    }

    private void Update()
    {
        if (objectToScale.activeSelf.Equals(true))
        {         
            if (scaleCoroutine != null)
                StopCoroutine(scaleCoroutine);
                scaleCoroutine = StartCoroutine(ScaleOverTime(objectToScale, maxsize, Up_Speed));
        }
    }

    private IEnumerator ScaleOverTime(GameObject targetObj, Vector3 toScale, float Up_Speed)
    {
        float counter = 0;
        Vector3 startScaleSize = targetObj.transform.localScale;

        while (counter < Up_Speed)
        {
            counter += Time.deltaTime;
            targetObj.transform.localScale = Vector3.Lerp(startScaleSize, toScale, ((Up_Speed * Time.deltaTime)*0.01f));

            yield return null;
        }
    }
}
