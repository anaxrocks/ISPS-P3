using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDelivery : MonoBehaviour
{
    public void ToDeliveryGame()
        {
            Time.timeScale = 1f; // Reset time scale in case the game was paused
            SceneManager.LoadScene("DeliveryGame");
        }
}
