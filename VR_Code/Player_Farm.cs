using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Farm : MonoBehaviour
{
    [SerializeField] GameObject Fam_anim;
    [SerializeField] GameObject Fam_Ground;
    [SerializeField] GameObject Fam_Fild;

    public int Fam_Try_num = 15;
    int C;

    Vector3 Y_Ground;
    
    void Start()
    {
        Y_Ground = Fam_Ground.transform.position;

        float Y_move;
        Y_move = (Y_Ground.y - (Fam_Try_num * 0.01f));

        Fam_Ground.transform.position = new Vector3(Fam_Ground.transform.position.x, (float)Y_move, Fam_Ground.transform.position.z);
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("±ªÀÌ³¯"))
        {
            if (!Fam_anim.activeSelf.Equals(false))
                Substitute();

            StartCoroutine(Fam_Up());
        }
    }

    public void Substitute()
    {
        Fam_anim.SetActive(false);
        Fam_Ground.SetActive(true);
    }

    IEnumerator Fam_Up()
    {
        Vector3 Now_Ground;
        Now_Ground = Fam_Fild.transform.position;

        C++;
        float YY = (Now_Ground.y + (C * 0.01f));
        var Up_speed = Time.deltaTime;

        if (Fam_Ground.transform.position.y < Y_Ground.y)
            Fam_Ground.transform.position = Vector3.MoveTowards(Fam_Ground.transform.position, new Vector3(Now_Ground.x, (float)YY, Now_Ground.z), (float)Up_speed);
        else
        {
            BoxCollider bx = this.gameObject.GetComponent<BoxCollider>();
            bx.enabled = false;
        }
        yield return null;
    }
}
