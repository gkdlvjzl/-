using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FarmUi : MonoBehaviour
{    
    [SerializeField] GameObject TextBox;
    [SerializeField] GameObject TextButton;

    private void Start()
    {
        TextButton.SetActive(false);
    }
    public void click_on()
    {
        TextBox.SetActive(true);
        TextButton.SetActive(true);
    }

    
}
