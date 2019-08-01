using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Spawner> spawners;
    private float nextSpawnTime;
    public ObjectPool objectPool;
    public GameObject ObjectPoolParent;

    int characterSpawned = 0;
    int characterDamage = 1;
    int characterPoints = 1;

    float powerUpCooldown = 5f;
    float currentpowerUpTime = 5f;

    private bool screenFree = false;

    private void Start()
    {
        for(int i=0; i<prefabs.Count; i++)
        {
            objectPool.AddPrototype(prefabs[i]);
        }
        objectPool.AddParentObject(ObjectPoolParent);

        nextSpawnTime = Random.Range(0, 4);
        LoadingScreen.main.ChangeColorInstantly(Color.black);
        StartCoroutine(ClearScreen());
    }

    private IEnumerator ClearScreen()
    {
        yield return StartCoroutine(LoadingScreen.main.ChangeColor(Color.clear));
        screenFree = true;
    }

    // TODO : Different points and damage
    void Update()
    {
        if (!screenFree) return;

        if(nextSpawnTime <= 0)
        {
            RandomSpawn(currentpowerUpTime < 0);
            nextSpawnTime = Random.Range(0.4f, 4f);

            characterSpawned++;
            if(characterSpawned > 4 * characterDamage)
            {
                characterSpawned = 0;
                characterDamage++;
                characterPoints++;
            }
        }

        currentpowerUpTime -= Time.deltaTime;

        nextSpawnTime -= Time.deltaTime;
    }

    private void RandomSpawn(bool _spawnPowerUp)
    {
        GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Count)];
        Spawner randomSpawner = spawners[Random.Range(0, spawners.Count)];
        BaseCharacterController c;
        if (_spawnPowerUp)
        {
            c = new PowerCharacterController();
            currentpowerUpTime = powerUpCooldown;
        }
        else
        {
            c = new BaseCharacterController();
        }

        randomSpawner.Spawn(randomPrefab, characterDamage, characterPoints, objectPool, c);
        
    }
}
