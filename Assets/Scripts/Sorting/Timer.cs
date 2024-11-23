using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public Player player;
    public float gameTimer;
    public bool timerRunning = false;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = Currency.pSortTimer;
        if (Tutorial.tutorial == true)
        {
            timerRunning = false;
        } else
        {
            timerRunning = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (gameTimer > 0) 
            {
                gameTimer -= Time.deltaTime;
                displayTimer(gameTimer);
            } else {
                gameTimer = 0;
                timerRunning = false;
                player.showSummary();
                // SceneManager.LoadScene("DeliveryGame");
            }
        }
    }
    void displayTimer(float timeRemaining)
    {
        timeRemaining += 1;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
