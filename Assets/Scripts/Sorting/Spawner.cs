using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] packages;
    public float timetoSpawn; // Initial spawn interval
    public float spawnCountdown;
    public float speedupFactor = 0.95f; // Factor to reduce spawn time
    public float minSpawnTime; // Minimum spawn interval to prevent it from becoming too fast
    public float speedupInterval = 10f; // Time between each speedup

    private float timeSinceLastSpeedup = 0f; // Track elapsed time since last speedup

    void Start()
    {
        spawnCountdown = timetoSpawn;
    }

    void Update()
    {
        // Count down to the next spawn
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0)
        {
            spawnCountdown = timetoSpawn;
            int randomPackage = Random.Range(1, packages.Length);
            if (randomPackage >= packages.Length)
            {
                randomPackage = 0; // rock
            }
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 8), Random.Range(4, 8), 0);
            Instantiate(packages[randomPackage], randomSpawnPosition, Quaternion.identity);
        }

        // Gradually speed up the spawning
        timeSinceLastSpeedup += Time.deltaTime;
        if (timeSinceLastSpeedup >= speedupInterval)
        {
            timeSinceLastSpeedup = 0f; // Reset speedup timer
            timetoSpawn = Mathf.Max(timetoSpawn * speedupFactor, minSpawnTime); // Decrease spawn time
        }
    }
}
