using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveAngle;
    public Sprite broken;
    public bool fade;
    public float deadTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deadTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true)
        {
            if (deadTime <= 0)
            {
                Destroy(this.gameObject);
            } else {
                deadTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.GetComponent<Rigidbody2D>());
            this.GetComponent<SpriteRenderer>().sprite = broken;
            fade = true;
        }
    }
}
