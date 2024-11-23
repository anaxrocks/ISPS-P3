using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the laser
    private Camera mainCamera;
    private Vector2 screenBounds;

    void Start()
    {
        // Get the screen bounds based on the camera's view
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        // Move the package in a straight line (rightward)
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Destroy the laser if it goes out of bounds
        if (transform.position.x > screenBounds.x ||
            transform.position.y > screenBounds.y ||
            transform.position.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BeachBall"))
        {
            // Destroy the package
            Destroy(other.gameObject);
        }
    }
    
}
