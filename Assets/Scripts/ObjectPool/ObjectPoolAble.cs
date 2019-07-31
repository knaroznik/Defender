using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolAble : MonoBehaviour
{

    private ObjectPool objectPool;

    public void InitObject(ObjectPool _objectPool)
    {
        objectPool = _objectPool;
    }

    protected virtual void ResetObject()
    {
        
    }

    public void Destroy()
    {
        ResetObject();
        objectPool.ReleaseReusable(this.gameObject);
    }
}