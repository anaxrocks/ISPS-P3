using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] packages;
    public float timetoSpawn, spawnCountdown;

    void Start() 
    {
        spawnCountdown = timetoSpawn;
    }
    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0)
        {
            spawnCountdown = timetoSpawn;
            int randomPackage = Random.Range(1, packages.Length + Upgrades.lessGarbage);
            if (randomPackage >= packages.Length) {
                randomPackage = 0; //rock
            }
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8,8), Random.Range(4,8), 0);

            Instantiate(packages[randomPackage], randomSpawnPosition, Quaternion.identity);
        }
    }
}
