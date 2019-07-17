using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color pathColor = Color.white;
    public TowerHealth playerHealth;

    [HideInInspector]
    public bool _drawGizmos = false;

    private List<Transform> redirectedPath;

    private void OnDrawGizmos()
    {
        Gizmos.color = pathColor;
        Transform[] tempArray = GetComponentsInChildren<Transform>();
        List<Transform> mainList = new List<Transform>();

        foreach (Transform x in tempArray)
        {
            if (x != this.transform)
            {
                mainList.Add(x);
            }
        }

        if (_drawGizmos)
        {
            for (int i = 0; i < mainList.Count; i++)
            {
                Vector3 position = mainList[i].position;
                if (i > 0)
                {
                    Vector3 prevPosition = mainList[i - 1].position;
                    Gizmos.DrawLine(prevPosition, position);
                    Gizmos.DrawWireSphere(position, 0.3f);
                }
            }
        }

        mainList.Reverse();
        redirectedPath = mainList;
    }

    private void CreatePath()
    {
        Transform[] tempArray = GetComponentsInChildren<Transform>();
        List<Transform> mainList = new List<Transform>();

        foreach (Transform x in tempArray)
        {
            if (x != this.transform)
            {
                mainList.Add(x);
            }
        }

        mainList.Reverse();
        redirectedPath = mainList;
    }

    public void AddDefaultPoint()
    {
        GameObject x = new GameObject();
        x.transform.parent = this.transform;
        CreatePath();
    }

    public Vector3 GetPosition(int _value)
    {
        if(redirectedPath == null)
        {
            CreatePath();
        }
        return redirectedPath[_value].position;
    }

    public Transform GetTransform(int _value)
    {
        if (redirectedPath == null)
        {
            CreatePath();
        }
        return redirectedPath[_value];
    }

    public int Length()
    {
        return redirectedPath.Count;
    }
}
