using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Posion : MonoBehaviour
{
    static public Player_Posion instance;

    [SerializeField] Transform play_posion;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Start()
    {
        play_posion = GetComponent<Transform>();
    }

    public void Save_posion()
    {
       
    }





}
