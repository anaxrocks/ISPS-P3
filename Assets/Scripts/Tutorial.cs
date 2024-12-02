using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject HubIntro;
    public GameObject Instructions;
    public GameObject StartButton;

    public static bool tutorial = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (tutorial == true)
        {
            Instructions.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial == true)
        {
            HubIntro.SetActive(true);
        } 
    }

    public void SetTutorialFalse()
    {
        tutorial = false;
        print(tutorial);
    }

    public void RemoveInstructions()
    {
        Instructions.SetActive(false);
        StartButton.SetActive(false);
    }
}
