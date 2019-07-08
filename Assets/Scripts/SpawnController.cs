using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Spawner> spawners;
    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Random.Range(0, 4);
    }
    // Update is called once per frame
    void Update()
    {
        if(nextSpawnTime <= 0)
        {
            RandomSpawn();
            nextSpawnTime = Random.Range(0, 4);
        }

        nextSpawnTime -= Time.deltaTime;
    }

    private void RandomSpawn()
    {
        GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Count)];
        Spawner randomSpawner = spawners[Random.Range(0, spawners.Count)];
        randomSpawner.Spawn(randomPrefab);
    }
}
