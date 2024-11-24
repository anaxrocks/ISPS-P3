using UnityEngine;

public class RepController : MonoBehaviour
{
    //public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public Sprite[] reputationSprites;   // Array of reputation sprites (assign in Inspector)
    void Start()
    {
        // Update the sprite to match the initial reputation value
        UpdateReputationSprite(Currency.repHome);
    }
    // reputation values can only be 0-5
    public void UpdateReputationSprite(int reputation)
    {
        GetComponent<SpriteRenderer>().sprite = reputationSprites[reputation];
    }
}
