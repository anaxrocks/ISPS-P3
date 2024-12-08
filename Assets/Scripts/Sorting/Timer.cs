using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public Timer instance;
    public Player player;
    public static float gameTimer;
    public bool timerRunning = false;

    public TextMeshProUGUI timerText;

    public float spawnCountdown;
    public GameObject clockLife;
    private int hasSpedUp;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayMusic("sorting slow");
        hasSpedUp = 0;
        gameTimer = Currency.pSortTimer;
        if (Tutorial.tutorial == true)
        {
            timerRunning = false;
        } else
        {
            timerRunning = true;
        }
        spawnCountdown = Random.Range(8.0f, 15.0f);
    }

    void Update()
    {
        //extra time spawner
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0 && PlanetSelection.selectedPlanet > 0)
        {
            spawnCountdown = Random.Range(8.0f - PlanetSelection.selectedPlanet, 15.0f);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 8), Random.Range(5, 9), 0);
            Instantiate(clockLife, randomSpawnPosition, Quaternion.identity);
        }

        if (gameTimer < 30.0f && hasSpedUp == 0)
        {
            MusicManager.Instance.PlayMusic("sorting medium", -0.5f);
            hasSpedUp++;
        }
        if (gameTimer < 10.0f && hasSpedUp == 1)
        {
            MusicManager.Instance.PlayMusic("sorting fast", -0.5f);
            hasSpedUp++;
        }
        //display timer
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
    public static void extraLife(float additionalTime)
    {
        gameTimer += additionalTime;
    }
    public static void misTime()
    {
        gameTimer -= 1.0f;
    }
}
