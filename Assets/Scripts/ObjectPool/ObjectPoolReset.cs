using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolReset : MonoBehaviour
{
    public List<ObjectPool> objectPools;

    void Awake()
    {
        for(int i=0; i<objectPools.Count; i++)
        {
            objectPools[i].ResetPool();
        }
        

    }
}
