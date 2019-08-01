using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    public virtual void Read(string x)
    {
        Debug.Log(x);
    }

    public virtual IEnumerator Action(Tower player)
    {
        yield return null;
    } 
}
