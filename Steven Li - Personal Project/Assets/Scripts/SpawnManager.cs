using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Public/private floats
    public GameObject[] foodPrefabs;
    private float SpawnRangeX = 12;
    private float SpawnPosZ = 6;
    private float startDelay = 2;
    private float spawnInterval = 2;
    // Start is called before the first frame update
    void Start()
    {
        //Makes animals spawn automatically by continuing to invoke the script SpawnRandomAnimal.
        InvokeRepeating("SpawnRandomFood", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnRandomFood()
    {
        //Makes all 3 animals spawn randomly within the given SpawnRange.
        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, SpawnPosZ);
        Instantiate(foodPrefabs[foodIndex], spawnPos, foodPrefabs[foodIndex].transform.rotation);
    }
}
