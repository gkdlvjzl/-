using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fam_this : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Arie;
    [SerializeField] Transform Fam;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(25, 1, 25));
    }

    private void Update()
    {
        float Dir = Vector3.Distance(Fam.position, Player.transform.position);

        if (Dir < 200f && Dir > 16f)
            Arie.SetActive(true);
        else
            Arie.SetActive(false);
    }

}
