using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance for global access

    // UI Text elements
    public Text scoreText; // Displays the score
    public Text packagesDeliveredText; // Displays packages delivered
    public Text packagesLeftText; // Displays packages left
    public Text hpText; // Displays player HP

    public GameObject gameOverCanvas; // Game Over panel to display at the end

    public Text gameOverScoreText;   // Reference to the ScoreText on Game Over Screen


    // Game stats
    private int score = 0; // Player's score
    private int packagesDelivered = 0; // Number of packages delivered
    public int packagesLeft; // Total packages to be delivered
    private int hp; // Player health points
    public int activePackages;
    public float acceleration; //time speed up, used for spawner and stuffs.
    public float satellite_speed;
    public float rock_speed;

    void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        if (Tutorial.tutorial == true)
        {
            packagesLeft = 10000000;
        } else
        {
            packagesLeft = Currency.pSorted;
        }
            
        if (packagesLeft == 0)
        {
            TriggerGameOver();
        }
        //unpauses game
        Time.timeScale = 1f;

        acceleration = 0.01f;
        satellite_speed = 1;
        rock_speed = 10;
    }

    void Start()
    {
        if (Tutorial.tutorial == true)
        {
            hp = 100000000;
        } else
        {
            hp = Upgrades.moreHealth;
        }
        UpdateUI(); // Initialize UI with default values
        activePackages = 0;
    }
    void Update()
    {
        satellite_speed += Time.deltaTime * acceleration;
        rock_speed += Time.deltaTime * acceleration;
    }

    public void AddScore(int points)
    {
        score += points; // Increase the score
        UpdateUI(); // Update the UI
    }

    public void DeliverPackage()
    {
        packagesDelivered++; // Increment packages delivered
        AddScore(10); // Add score for delivering a package (optional)
        UpdateUI();

        if (packagesLeft <= 0)
        {
            TriggerGameOver();
        }
    }

    public void TakeDamage()
    {
        SpaceShipScript.instance.FlashRed(0.1f);
        hp--; // Decrement player health
        UpdateUI();

        if (hp <= 0)
        {
            TriggerGameOver();
        }
    }

    public void ShootPackage()
    {
        if (packagesLeft > 0)
        {
            packagesLeft--; // Decrease packages left
            activePackages++;
            UpdateUI(); // Refresh the UI to show the new count
        }
        // else
        // {
        //     TriggerGameOver(); // No packages left, trigger game over
        // }
    }
    public void PackageDestroyed()
    {
        activePackages--;
        if (packagesLeft <= 0 && activePackages == 0)
        {
            TriggerGameOver();
        }
        if (Tutorial.tutorial == true && score == 5)
        {
            TriggerGameOver();
        }
    }

    private void UpdateUI()
    {
        // Update all the UI elements
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (packagesDeliveredText != null)
            packagesDeliveredText.text = "Packages Delivered: " + packagesDelivered;

        if (Tutorial.tutorial == false)
        {
            if (packagesLeftText != null)
            packagesLeftText.text = "Packages Left: " + packagesLeft;
        
            if (hpText != null)
                hpText.text = "HP: " + hp;
        }
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over");

        // Activate the Game Over Canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);

            // Display the final score
            if (gameOverScoreText != null)
            {
                gameOverScoreText.text = "Score: " + score;
            }
        }

        Currency.pDelivered = score;
        print(Currency.pDelivered);
       
        // Pause the game (optional)
        Time.timeScale = 0f;
    }
}
