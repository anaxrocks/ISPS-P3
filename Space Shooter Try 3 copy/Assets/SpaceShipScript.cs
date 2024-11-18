using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float thrusterForce = 5;
    private Camera mainCamera;
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Mathf.Abs(mainCamera.transform.position.z)));

        // Get object's dimensions
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Half the width
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y; // Half the height
    }

    void Update()
    {
        Vector3 objectPosition = transform.position;

        // Clamp the object's position
        objectPosition.x = Mathf.Clamp(objectPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = objectPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * thrusterForce;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidbody.velocity = Vector2.right * thrusterForce;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = Vector2.left * thrusterForce;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidbody.velocity = Vector2.down * thrusterForce;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
{
    // Check if the collision is with a BeachBall
    if (other.gameObject.CompareTag("BeachBall"))
    {
        // Decrease HP via ScoreManager
        ScoreManager.instance.TakeDamage();
    }
}
}