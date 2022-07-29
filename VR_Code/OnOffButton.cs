using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;
    public void click_off()
    {
        button.SetActive(false);
        panel.SetActive(true);
    }
}
