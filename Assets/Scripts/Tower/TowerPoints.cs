using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoints : MonoBehaviour
{
    private TowerUI uiHandler;

    private void Start()
    {
        uiHandler = GetComponent<TowerUI>();
    }

    private int points = 0;

    public void AddPoints(int _value)
    {
        points += _value;
        uiHandler.UpdatePoints(points);
    }
}
