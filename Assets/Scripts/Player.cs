using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    private float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mouse.x;
        if (mouseX < -9.5f)
        {
            mouseX = -9.5f;
        }
        if (mouseX > 9.5f)
        {
            mouseX = 9.5f;
        }
        
        transform.position = new Vector3(mouseX, transform.position.y, transform.position.z);
    }
}
