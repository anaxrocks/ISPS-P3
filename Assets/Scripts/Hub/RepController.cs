using UnityEngine;

public class RepController : MonoBehaviour
{
    //public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public Sprite[] reputationSprites;   // Array of reputation sprites (assign in Inspector)

    void Start()
    {
        // Update the sprite to match the initial reputation value
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on the GameObject. Please add one.");
            return; // Stop execution if no SpriteRenderer is found
        }

        UpdateReputationSprite(Currency.repHome);
    }

    void Update()
    {
        // Continuously check for reputation changes and update the sprite
        UpdateReputationSprite(Currency.repHome);
    }

    public void UpdateReputationSprite(int reputation)
    {
        if (reputation >= 3 && reputation < reputationSprites.Length + 1)
        {
            spriteRenderer.sprite = reputationSprites[reputation - 1];
        }
        else
        {
            Debug.LogWarning("Reputation value out of range: " + reputation);
        }
    }
}
