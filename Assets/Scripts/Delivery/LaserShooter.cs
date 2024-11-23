using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    // public GameObject packagePrefab; // Prefab to shoot

    public GameObject laser; //Prefabs to shoot

    public float spawnOffset = 1f; // Distance in front of the spaceship

    public float LasershootSpeed = 5f;    // Speed of the laser
    public float timeForShootResetLaser, shootCountdownLaser;


    void Start() 
    {
        if (Upgrades.addLasersCounter > 0)
        {
            timeForShootResetLaser = 2.0f / Upgrades.addLasersCounter;
        }
        else{
            timeForShootResetLaser = Mathf.Infinity;
        }
    }

    void Update()
    {
        shootCountdownLaser -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J) && shootCountdownLaser <= 0 && Upgrades.addLasersCounter > 0)
        {
            Debug.Log("Laser shoot Enabled 2");
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // Ensure there are packages left to shoot
        shootCountdownLaser = timeForShootResetLaser;
        if (ScoreManager.instance != null)
        {

            
            if (Upgrades.addLasersCounter > 0)
            {
                // Calculate spawn position
                Vector3 spawnPosition = transform.position + new Vector3(spawnOffset, 0.15f, 0f);

                // Instantiate the package prefab
            // GameObject package = Instantiate(packagePrefab, spawnPosition, Quaternion.identity);
            GameObject laser1 = Instantiate(laser, spawnPosition, Quaternion.identity);
            Rigidbody2D rb = laser1.GetComponent<Rigidbody2D>();
            if (rb != null)
                {
                    rb.velocity = Vector3.right * LasershootSpeed; // Force it to move right in world space
                } // Use no rotation (straight alignment)
            }
        }
    }
}
