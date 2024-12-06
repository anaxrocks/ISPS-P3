using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 5f; // Initial speed of player movement
    public float maxMoveSpeed = 10f; // Maximum player movement speed
    public float speedIncrement = 0.1f; // Amount to increase speed
    public float speedUpInterval = 10f; // Time interval to increase speed
    private float speedUpTimer; // Timer to track speed-up intervals
    private float horizontalInput;

    private Queue packageStack = new Queue();
    public Transform[] stackSlots; //visual stack above player
    /*  0 rock
        1 garden package
        2 ocean package
        3 cowboy package
        4 cat package
        5 closed package
    */
    public Sprite[] packageSprites; //list of sprites, must be same order as packages
    public Sprite[] binSprites; //list of bin sprites
    public Sprite[] binClosed; //list of bin closed sprites
    public Transform[] bins; //list of bins. Bins are 1-indexed
    public TextMeshProUGUI scoreText; //PSorted
    private bool containsRock;

    //for player movement
    bool facingRight = true;

    public GameObject summaryCanvas; //Summary once timer is over. 
    public TextMeshProUGUI summaryText; //for summary screen

    public bool drop1;
    public bool drop2;
    public bool drop3;
    public bool drop4;
    public bool discard;
    public int maxStack;
    public int p1; // count for package 1 and so on
    public int p2;
    public int p3;
    public int p4;

    public float timetoReset; //time to reset bin if player mis-sorted
    private float[] binCountdown = new float[4];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) 
        {
            binCountdown[i] = 0.0f;
        }
        maxStack = Upgrades.handLimit;
        containsRock = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Detect key input for movement
        if (Input.GetKey(KeyCode.A))
        {
            // Move left
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // Flip character if facing right
            if (facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // Flip character if facing left
            if (!facingRight)
            {
                Flip();
            }
        }
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -7.8f, 7.8f);
        transform.position = clampedPosition;

        // Speed-Up Timer
        speedUpTimer += Time.deltaTime;
        if (speedUpTimer >= speedUpInterval)
        {
            // Increase player movement speed
            moveSpeed = Mathf.Clamp(moveSpeed + speedIncrement, 0, maxMoveSpeed);

            // Reset timer
            speedUpTimer = 0f;
        }

        //Decrease bin countdown if above zero, or open bins (visually)
        for (int i = 0; i < 4; i++) 
        {
            if (binCountdown[i] > 0) 
            { 
                binCountdown[i] -= Time.deltaTime; 
            }
            else {
                openBin(i);
            }
        }

        //check if rock
        if (!packageStack.Contains(0)) {
            containsRock = false;
        }
        if (drop1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && packageStack.Count > 0
                && binCountdown[0] <=0)
            {
                if (packageStack.Peek().Equals(1))
                {
                    p1 += 1;
                    print("package 1 added to bin");
                    SoundManager.Instance.PlaySound2D("Pop");
                }
                else 
                {
                    print("mis-sort!");
                    closeBin(1);
                }
                PopFromQueue();
            }
        }

        if (drop2)
        {
            if (Input.GetKeyDown(KeyCode.Space) && packageStack.Count > 0
                && binCountdown[1] <=0)
            {
                if (packageStack.Peek().Equals(2))
                {
                    p2 += 1;
                    print("package 2 added to bin");
                    SoundManager.Instance.PlaySound2D("Pop");
                }
                else 
                {
                    print("mis-sort!");
                    closeBin(2);
                }
                PopFromQueue();
            }
        }

        if (drop3)
        {
            if (Input.GetKeyDown(KeyCode.Space) && packageStack.Count > 0
                && binCountdown[2] <=0)
            {
                if (packageStack.Peek().Equals(3))
                {
                    p3 += 1;
                    print("package 3 added to bin");
                    SoundManager.Instance.PlaySound2D("Pop");
                }
                else 
                {
                    print("mis-sort!");
                    closeBin(3);
                }   
                PopFromQueue();
            }
        }

        if (drop4)
        {
            if (Input.GetKeyDown(KeyCode.Space) && packageStack.Count > 0
                && binCountdown[3] <=0)
            {
                if (packageStack.Peek().Equals(4))
                {
                    p4 += 1;
                    print("package 4 added to bin");
                    SoundManager.Instance.PlaySound2D("Pop");
                }
                else 
                {
                    print("mis-sort!");
                    closeBin(4);
                }
                PopFromQueue();
            }
        }
        //Can discard any package or rock
        if (discard)
        {
            if (Input.GetKeyDown(KeyCode.Space) && packageStack.Count > 0)
            {
                if (packageStack.Count != 0)
                {
                    PopFromQueue();
                    print("discarded package");
                    SoundManager.Instance.PlaySound2D("Pop");
                }
            }
        }

        Currency.pSorted = p1 + p2 + p3 + p4;

        if (Tutorial.tutorial == true)
        {
            scoreText.text = "Score: " + Currency.pSorted.ToString() + " / 5";
            if (Currency.pSorted == 5)
            {
                showSummary();
            }
        }
        else
        {
            scoreText.text = "Score: " + Currency.pSorted.ToString();
        }
    }

    /* Use this to add to stack and also take care of the visuals! Does not
        check for stack size so careful~
    */
    private void AddToStack(int i)
    {
        int size = packageStack.Count;
        stackSlots[size].GetComponent<SpriteRenderer>().sprite = packageSprites[i];
        packageStack.Enqueue(i);
    }

    /* Use this to pop from stack and also take care of the visuals! Does not
        check for stack size so careful~
    */
    private void PopFromQueue()
    {
        int size = packageStack.Count;
        packageStack.Dequeue();
        for (int i = 0; i < packageStack.Count; i++)
        {
            stackSlots[i].GetComponent<SpriteRenderer>().sprite = 
                stackSlots[i+1].GetComponent<SpriteRenderer>().sprite;
        }
        stackSlots[size-1].GetComponent<SpriteRenderer>().sprite = null;
    }
    /* Closes the bin for a missort. Bins are 1-indexed. */
    private void closeBin(int i)
    {
        Currency.pMiss += 1;
        //5 is the index for a closed package
        bins[i-1].GetComponent<SpriteRenderer>().sprite = binClosed[i-1];
        binCountdown[i-1] = timetoReset;
        SoundManager.Instance.PlaySound2D("Missort");
    }
    
    /* Call this to open the bin again (visually). 0-indexed. */
    private void openBin(int i)
    {
        bins[i].GetComponent<SpriteRenderer>().sprite = binSprites[i];
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    /* Shows how many packages were sorted */
    public void showSummary()
    {
        summaryCanvas.SetActive(true);
        Time.timeScale = 0f; //pause game
        summaryText.text = "Score: " + Currency.pSorted.ToString();
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Package1") {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                !containsRock) ||
                packageStack.Count == 0)
            {
                AddToStack(1);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Package2")
        {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                !containsRock) ||
                packageStack.Count == 0)
            {
                AddToStack(2);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Package3")
        {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                !containsRock) ||
                packageStack.Count == 0)
            {
                AddToStack(3);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Package4")
        {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                !containsRock)||
                packageStack.Count == 0)
            {
                AddToStack(4);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Rock")
        {
            if (packageStack.Count < maxStack &&
                packageStack.Count > 0 ||
                packageStack.Count == 0)
            {
                AddToStack(0);
                containsRock = true;
                print(packageStack.Peek());
                SoundManager.Instance.PlaySound2D("Rock Falling");
            }
        }

        if (other.gameObject.tag == "Bin1")
        {
            drop1 = true;
        }

        if (other.gameObject.tag == "Bin2")
        {
            drop2 = true;
        }

        if (other.gameObject.tag == "Bin3")
        {
            drop3 = true;
        }

        if (other.gameObject.tag == "Bin4")
        {
            drop4 = true;
        }

        if (other.gameObject.tag == "Discard")
        {
            discard = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bin1")
        {
            drop1 = false;
        }

        if (other.gameObject.tag == "Bin2")
        {
            drop2 = false;
        }

        if (other.gameObject.tag == "Bin3")
        {
            drop3 = false;
        }

        if (other.gameObject.tag == "Bin4")
        {
            drop4 = false;
        }

        if (other.gameObject.tag == "Discard")
        {
            discard = false;
        }
    }
}
