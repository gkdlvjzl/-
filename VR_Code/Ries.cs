using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ries : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] GameObject Farm_this;

    public GameObject objectToScale;
    public float Up_Speed;
    public Vector3 minsize;
    public Vector3 maxsize;
    public Coroutine scaleCoroutine;

    public int Count_cut_ries = 5;

    float full_up = 0.9f;

    BoxCollider bx;

    private void Start()
    {
        objectToScale.transform.localScale = minsize;
        bx = this.gameObject.GetComponent<BoxCollider>();
        bx.enabled = false;
    }

    private void Update()
    {
        if (objectToScale.activeSelf.Equals(true))
        {         
            if (scaleCoroutine != null)
                StopCoroutine(scaleCoroutine);
                scaleCoroutine = StartCoroutine(ScaleOverTime(objectToScale, maxsize, Up_Speed));
        }
        if (objectToScale.transform.localScale.y > full_up)
        {
            bx.enabled = true;
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

    void Cut_Ries()
    {
        Vector3 this_here = new (Farm_this.transform.position.x + Random.Range(-1,1), Farm_this.transform.position.y + (Random.Range(0.1f,1))
            , Farm_this.transform.position.z + (Random.Range(-1, 1)));

        if (objectToScale.transform.localScale.y > full_up)
        {
            if (Count_cut_ries < 1)
            {
                gameObject.SetActive(false);
                objectToScale.transform.localScale = minsize;

                Instantiate(item, this_here, Quaternion.LookRotation(Vector3.up), Farm_this.transform);
            }
            else
            {
                Count_cut_ries--;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("³´³¯"))
        {
            Cut_Ries();
        }
    }
}
