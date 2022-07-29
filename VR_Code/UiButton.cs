using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    public GameObject Exit;

    private void Start()
    {
        Exit.SetActive(false);
    }
    public void Exit_game()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }
    public void Exit_back()
    {
        Exit.SetActive(false);
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Exit.SetActive(true);
        }
    }
}
