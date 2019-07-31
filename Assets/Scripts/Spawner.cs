using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Path spawnerPath;

    public void Spawn(GameObject prefab, int damage, int points, ObjectPool pool)
    {
        if (spawnerPath.playerHealth.Alive())
        {
            GameObject x = pool.acquireReusable(prefab);
            x.transform.position = spawnerPath.GetPosition(0);
            x.transform.rotation = Quaternion.LookRotation(spawnerPath.GetPosition(1) - spawnerPath.GetPosition(0)) * Quaternion.Euler(0, -90, 0);
            x.GetComponent<Character>().SetUp(spawnerPath, damage, points, points);
        }
    }
}
