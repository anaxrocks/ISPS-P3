using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    private float mouseX;
    private Stack<int> packageStack = new Stack<int>();
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

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (drop1)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0)
            {
                if (packageStack.Peek() == 1)
                {
                    packageStack.Pop();
                    p1 += 1;
                    print("package 1 added to bin");
                }
            }
        }

        if (drop2)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0)
            {
                if (packageStack.Peek() == 2)
                {
                    packageStack.Pop();
                    p2 += 1;
                    print("package 2 added to bin");
                }
            }
        }

        if (drop3)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0)
            {
                if (packageStack.Peek() == 3)
                {
                    packageStack.Pop();
                    p3 += 1;
                    print("package 3 added to bin");
                }
            }
        }

        if (drop4)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0)
            {
                if (packageStack.Peek() == 4)
                {
                    packageStack.Pop();
                    p4 += 1;
                    print("package 4 added to bin");
                }
            }
        }

        if (discard)
        {
            if (Input.GetMouseButtonDown(0) && packageStack.Count > 0)
            {
                if (packageStack.Peek() == 0)
                {
                    packageStack.Pop();
                    print("discarded package");
                }
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Package1") {
            if ((packageStack.Count < maxStack &&
                packageStack.Count > 0 &&
                packageStack.Peek() != 0) ||
                packageStack.Count == 0)
            {
                packageStack.Push(1);
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
                packageStack.Push(2);
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
                packageStack.Push(3);
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
                packageStack.Push(4);
                print(packageStack.Peek());
            }
        }

        if (other.gameObject.tag == "Rock")
        {
            if (packageStack.Count < maxStack &&
                packageStack.Count > 0 ||
                packageStack.Count == 0)
            {
                packageStack.Push(0);
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
