using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallSpawner : MonoBehaviour
{
    public GameObject BeachBallPrefab;
    public float spawnRate = 5;

    public float minSpawnRate = 1;

    private float timer = 0;

    private Camera mainCamera;
    private float rightEdge;
    private float topEdge;
    private float bottomEdge;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found! Ensure the camera is tagged as 'MainCamera'.");
            return;
        }

        // Calculate the camera boundaries
        UpdateCameraEdges();
        SpawnBall();
    }

    void Update()
    {
        if (spawnRate > minSpawnRate)
        {
            spawnRate -= Time.deltaTime * ScoreManager.instance.acceleration;
        }
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            UpdateCameraEdges(); // Update edges dynamically if the camera moves
            SpawnBall();
            timer = 0;
        }
    }

    void SpawnBall()
    {
        // Spawn at the right edge with a random vertical position within the camera's visible range
        float spawnY = Random.Range(bottomEdge, topEdge);
        Instantiate(
            BeachBallPrefab,
            new Vector3(rightEdge, spawnY, 0),
            Quaternion.identity
        );
    }

    void UpdateCameraEdges()
    {
        // Get the world coordinates of the screen edges
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Mathf.Abs(mainCamera.transform.position.z)));
        Vector3 bottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, Mathf.Abs(mainCamera.transform.position.z)));

        rightEdge = topRight.x;  // Rightmost X coordinate
        topEdge = topRight.y;    // Topmost Y coordinate
        bottomEdge = bottomRight.y; // Bottommost Y coordinate
    }
}
