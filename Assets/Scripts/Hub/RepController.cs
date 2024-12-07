using UnityEngine;

public class RepController : MonoBehaviour
{
    //public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public Sprite[] reputationSprites;   // Array of reputation sprites (assign in Inspector)
    void Start()
    {
        UpdateReputationSprite();
    }

    public void UpdateReputationSprite()
    {
        int reputation = 0;
        string tag = gameObject.tag; // Get the tag of the target object

        switch (tag)
        {
            case "repHome":
                reputation = Currency.repHome;
                break;

            case "repWater":
                reputation = Currency.rep1;
                break;

            case "repCowboy":
                reputation = Currency.rep2;
                break;

            case "repGarden":
                reputation = Currency.rep3;
                break;

            case "repCat":
                reputation = Currency.rep4;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = reputationSprites[reputation];
    }
}
