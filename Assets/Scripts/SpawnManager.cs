using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the randomized spawning of the animals.

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    // Vertical spawning range and position
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    // Horizontal spawning range and position
    private float spawnRangeZ = 20;
    private float spawnPosX = 25;
    
    // Spawn timing
    private float startDelay = 1.5f;
    private float spawnInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length); // Randomly selecting the animal to spawn
        
        int spawnAxis = Random.Range(0, 2); // Randomly selecting the axis to spawn. 0 = vertical, 1 = horizontal

        Vector3 spawnPosition;

        if (spawnAxis == 0) // Vertical, animal to spawn at the top
        {
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(
                animalPrefabs[animalIndex],
                spawnPosition,
                animalPrefabs[animalIndex].transform.rotation
                );
        } 
        else // Horizontal, animal to spot at either left or right side
        {
            int side = Random.Range(0, 2); // Randomly selecting the side to spawn. 0 = left, 1 = right

            Quaternion spawnRotation;

            if (side == 0) // animal spawn in the left side
            {
                spawnPosition = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));
                spawnRotation = Quaternion.Euler(0, 90, 0);
            }
            else // animal spawn in the right side
            {
                spawnPosition = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));
                spawnRotation = Quaternion.Euler(0, -90, 0);
            }

            Instantiate(
                animalPrefabs[animalIndex],
                spawnPosition,
                spawnRotation
                );
        }
    }
}
