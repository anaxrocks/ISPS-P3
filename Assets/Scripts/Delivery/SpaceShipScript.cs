using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public static SpaceShipScript instance;
    public Rigidbody2D myRigidbody;
    public float thrusterForce = 10;
    private Camera mainCamera;
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public SpriteRenderer shipSprite;

    private Color originalColor;

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
    }
    void Start()
    {
        shipSprite = GetComponent<SpriteRenderer>();
        // if (shipSprite == null)
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Mathf.Abs(mainCamera.transform.position.z)));

        // Get object's dimensions
        objectWidth = shipSprite.bounds.extents.x; // Half the width
        objectHeight = shipSprite.bounds.extents.y; // Half the height
    }

    void Update()
    {
        Vector3 objectPosition = transform.position;

        // Clamp the object's position
        objectPosition.x = Mathf.Clamp(objectPosition.x, screenBounds.x * -1 
                        + objectWidth, screenBounds.x - objectWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, screenBounds.y * -1 
                        + objectHeight, screenBounds.y - objectHeight);
        transform.position = objectPosition;

        /* New version stops player if they are not hitting any keys */
         Vector2 newVelocity = Vector2.zero; // Start with no movement

        if (Input.GetKey ("w"))
        {
            newVelocity += Vector2.up * thrusterForce;
        }
        if (Input.GetKey ("d"))
        {
            newVelocity += Vector2.right * thrusterForce;
        }
        if (Input.GetKey ("a"))
        {
            newVelocity += Vector2.left * thrusterForce;
        }
        if (Input.GetKey ("s"))
        {
            newVelocity += Vector2.down * thrusterForce;
        }

        myRigidbody.velocity = newVelocity;
    }

    /* FlashRed will make the ship sprite flash red */
    public void FlashRed(float duration)
    {
        /* StartCoroutine is a special type of method that allows you to 
        execute code over multiple frames, like performing animations. */
        StartCoroutine(FlashRedCoroutine(duration));
    }

    /* Helper function for FlashRed. */
    private IEnumerator FlashRedCoroutine(float duration) 
    {

        shipSprite.color = Color.red; // Change color to red
        yield return new WaitForSeconds(duration); // Wait for the flash duration
        shipSprite.color = Color.white; // Revert to the original color
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collision is with a BeachBall
        if (other.gameObject.CompareTag("BeachBall"))
        {
            // Decrease HP via ScoreManager and flash the space ship red. 
            ScoreManager.instance.TakeDamage();
        }
    }
}