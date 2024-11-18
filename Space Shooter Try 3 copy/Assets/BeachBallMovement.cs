using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 10;
    public float deadZone = -45;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("SpaceShip"))
    {
        // Decrease HP
        ScoreManager.instance.TakeDamage();
    }
}
    
}
