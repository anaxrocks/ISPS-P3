using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float deadZone = -45;
    private float time;
    private Vector3 spawnPos;
    private float speed;
    void Start()
    {
        time = 0;
        spawnPos = transform.position;
        speed = ScoreManager.instance.satellite_speed;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float x = 3 * (time * speed); // x moves linearly with time
        float y = 0.2f * Mathf.Sin(5 * time); // y moves sinusoidally with time

        transform.position = spawnPos - new Vector3(x, y);
        // transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
        
    }
}
