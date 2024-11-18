using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartToTitleScreen()
    {
        Debug.Log("Restarting to Title Screen...");
        Time.timeScale = 1f; // Reset time scale in case the game was paused
        SceneManager.LoadScene("Summary"); // Replace with the name of your Title Screen scene
    }
}
