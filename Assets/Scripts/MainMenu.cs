using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool playedOnce = false;

    void Start() 
    {
        MusicManager.Instance.PlayMusic("main");
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        if (playedOnce){
            SceneManager.LoadScene("Hub");
        } else {
            SceneManager.LoadScene("IntroNarrative");
        }
    }
}
