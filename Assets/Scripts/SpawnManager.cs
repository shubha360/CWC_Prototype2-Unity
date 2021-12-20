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
    private float sideSpawnMinZ = 3;
    private float sideSpawnMaxZ = 15;
    private float sideSpawnX = 20;

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
        int spawn = Random.Range(0, 3); // 0 - top, 1 - left, 2 - right

        switch(spawn)
        {
            case 0:
                spawnTopAnimal();
                break;

            case 1:
                SpawnLeftAnimal();
                break;

            case 2:
                SpawnRightAnimal();
                break;
        }
    }

    void spawnTopAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPosition,
            animalPrefabs[animalIndex].transform.rotation
            );
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 spawnRotation = new Vector3(0, 90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(spawnRotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 spawnRotation = new Vector3(0, -90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(spawnRotation));
    }
}
