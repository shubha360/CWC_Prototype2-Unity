using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    // for vertical spawning
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    // for horizontal spawning
    private float spawnRangeZ = 20;
    private float spawnPosX = 25;
    
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnAxis = Random.Range(0, 2); // 0 = vertical, 1 = horizontal

        Vector3 spawnPosition;

        if (spawnAxis == 0)
        {
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(
                animalPrefabs[animalIndex],
                spawnPosition,
                animalPrefabs[animalIndex].transform.rotation
                );
        } else
        {
            int side = Random.Range(0, 2); // 0 = left, 1 = right

            Quaternion spawnRotation;

            if (side == 0)
            {
                spawnPosition = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));
                spawnRotation = Quaternion.Euler(0, 90, 0);
            } else
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
