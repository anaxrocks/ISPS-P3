using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageShooter : MonoBehaviour
{
    public GameObject packagePrefab; // Prefab to shoot
    public float spawnOffset = 1f; // Distance in front of the spaceship

    public float shootSpeed = 5f;    // Speed of the package


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootPackage();
        }
    }

    void ShootPackage()
    {
        // Ensure there are packages left to shoot
        if (ScoreManager.instance != null)
        {
            if (ScoreManager.instance.packagesLeft > 0)
            {
                // Reduce packages left
                ScoreManager.instance.ShootPackage();

                // Calculate spawn position
                Vector3 spawnPosition = transform.position + new Vector3(spawnOffset, 0.15f, 0f);

                // Instantiate the package prefab
            GameObject package = Instantiate(packagePrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D rb = package.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector3.right * shootSpeed; // Force it to move right in world space
            } // Use no rotation (straight alignment)
            }
            else
            {
                ScoreManager.instance.TriggerGameOver();
            }
        }
    }
}
