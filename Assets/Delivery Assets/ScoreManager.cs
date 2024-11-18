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
    public int packagesLeft = 10; // Total packages to be delivered
    private int hp = 3; // Player health points

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

        DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
    }

    void Start()
    {
        UpdateUI(); // Initialize UI with default values
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
        UpdateUI(); // Refresh the UI to show the new count
    }
    else
    {
        TriggerGameOver(); // No packages left, trigger game over
    }
}


    private void UpdateUI()
    {
        // Update all the UI elements
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (packagesDeliveredText != null)
            packagesDeliveredText.text = "Packages Delivered: " + packagesDelivered;

        if (packagesLeftText != null)
            packagesLeftText.text = "Packages Left: " + packagesLeft;

        if (hpText != null)
            hpText.text = "HP: " + hp;
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

        // Pause the game (optional)
        Time.timeScale = 0f;
    }
}
