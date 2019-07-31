using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectPool class. Keeps all prototypes of spawners even between scenes. 
/// FUNCTIONS : Replace Destroy() and Instantiate() functions for application optimalization.
/// LINKING : Must be linked in each spawner and object to reset it between scenes.
/// </summary>
public class ObjectPool : ScriptableObject
{

    /// <summary>
    /// Available objects of scene.
    /// </summary>
    private Dictionary<string, List<GameObject>> _available = new Dictionary<string, List<GameObject>>();

    /// <summary>
    /// Available prototypes. Should be added on start of scene.
    /// </summary>
    private Dictionary<string, GameObject> _prototypes = new Dictionary<string, GameObject>();
    private Transform objectPoolParent;

    /// <summary>
    /// Reset Pool. Done between scenes.
    /// </summary>
    public void ResetPool()
    {
        _available = new Dictionary<string, List<GameObject>>();
        _prototypes = new Dictionary<string, GameObject>();
        objectPoolParent = null;
    }

    /// <summary>
    /// Returns new object of wanted type. Type is name of GameObject.
    /// </summary>
    /// <param name="wantedObject">Object which copy should be returned.</param>
    /// <returns>New reseted GameObject</returns>
    public GameObject acquireReusable(GameObject wantedObject)
    {
        string type = wantedObject.name;
        GameObject item;
        lock (this)
        {
            if (_available[type].Count > 0)
            {
                item = _available[type][0];
                item.transform.SetParent(null);
                _available[type].RemoveAt(0);
                item.SetActive(true);
            }
            else
            {
                item = GameObject.Instantiate(_prototypes[type]);
                item.GetComponent<ObjectPoolAble>().InitObject(this);
            }
        }

        item.name = type;

        return item;
    }

    public void ReleaseReusable(GameObject item)
    {
        string type = item.name;
        _available[type].Add(item);
        item.SetActive(false);
        item.transform.SetParent(objectPoolParent);
    }

    public void AddPrototype(GameObject obj)
    {
        string type = obj.name;
        if (!_prototypes.ContainsKey(type))
        {

            _prototypes.Add(type, obj);
            _available.Add(type, new List<GameObject>());
        }
    }

    public void AddParentObject(GameObject obj)
    {
        objectPoolParent = obj.transform;
    }
}
