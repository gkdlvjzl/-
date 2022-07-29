using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_On : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] GameObject Water;

    public float View_off = 500f;

    private void Update()
    {
        float Dir = Vector3.Distance(Player.position, this.gameObject.transform.position);

        if (Dir > View_off)
            Water.SetActive(false);
        else
            Water.SetActive(true);
    }
}
