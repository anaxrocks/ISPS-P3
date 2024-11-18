using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    private float mouseX;

    private Stack<int> packageStack = new Stack<int>();
    public Transform[] stackSlots; //visual stack above player
    public Sprite[] packageSprites; //list of sprites, must be same order as packages

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
    }

    // Update is called once per frame
    void Update()
    {
        // Track mouse movement
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mouse.x;

        // Player can't drag off screen
        if (mouseX < -9.5f) {
            mouseX = -9.5f;
        }

        if (mouseX > 9.5f) {
            mouseX = 9.5f;
        }
        
        transform.position = new Vector3(mouseX, transform.position.y, transform.position.z);

        //Decrease bin countdown if above zero
        for (int i = 0; i < 4; i++) 
        {
            if (binCountdown[i] > 0) { binCountdown[i] -= Time.deltaTime; }
            
        }
        if (drop1)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0
                && binCountdown[0] <=0)
            {
                if (packageStack.Peek() == 1)
                {
                    p1 += 1;
                    print("package 1 added to bin");
                }
                else 
                {
                    print("mis-sort!");
                    binCountdown[0] = timetoReset;
                }
                PopFromStack();
                //packageStack.Pop();

            }
        }

        if (drop2)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0
                && binCountdown[1] <=0)
            {
                if (packageStack.Peek() == 2)
                {
                    p2 += 1;
                    print("package 2 added to bin");
                }
                else 
                {
                    print("mis-sort!");
                    binCountdown[1] = timetoReset;
                }
                PopFromStack();
                //packageStack.Pop();
            }
        }

        if (drop3)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0
                && binCountdown[2] <=0)
            {
                if (packageStack.Peek() == 3)
                {
                    p3 += 1;
                    print("package 3 added to bin");
                }
                else 
                {
                    print("mis-sort!");
                    binCountdown[2] = timetoReset;
                }   
                PopFromStack();
                //packageStack.Pop();;
            }
        }

        if (drop4)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0
                && binCountdown[3] <=0)
            {
                if (packageStack.Peek() == 4)
                {
                    p4 += 1;
                    print("package 4 added to bin");
                }
                else 
                {
                    print("mis-sort!");
                    binCountdown[3] = timetoReset;
                }
                PopFromStack();
                //packageStack.Pop();
            }
        }
        //Can discard any package or rock
        if (discard)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0)
            {
                if (packageStack.Count != 0)
                {
                    PopFromStack();
                    //packageStack.Pop();
                    print("discarded package");
                }
            }
        }
    }
    /* Use this to add to stack and also take care of the visuals! Does not
        check for stack size so careful~
    */
    private void AddToStack(int i)
    {
        int size = packageStack.Count;
        stackSlots[size].GetComponent<SpriteRenderer>().sprite = packageSprites[i];
        packageStack.Push(i);
    }
    private void PopFromStack()
    {
        int size = packageStack.Count;
        stackSlots[size - 1].GetComponent<SpriteRenderer>().sprite = null;
        packageStack.Pop();
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Package1") {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                packageStack.Peek() != 0) ||
                packageStack.Count == 0)
            {
                AddToStack(1);
                //packageStack.Push(1);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Package2")
        {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                packageStack.Peek() != 0) ||
                packageStack.Count == 0)
            {
                AddToStack(2);
                //packageStack.Push(2);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Package3")
        {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                packageStack.Peek() != 0) ||
                packageStack.Count == 0)
            {
                AddToStack(3);
                //packageStack.Push(3);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Package4")
        {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                packageStack.Peek() != 0)||
                packageStack.Count == 0)
            {
                AddToStack(4);
                //packageStack.Push(4);
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
                //packageStack.Push(0);
                print(packageStack.Peek());
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
