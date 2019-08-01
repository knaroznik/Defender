using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoints : MonoBehaviour
{
    private TowerUI uiHandler;
    public List<PowerUp> powerUps;

    private void Start()
    {
        uiHandler = GetComponent<TowerUI>();
    }

    public int points = 0;

    public void AddPoints(int _value)
    {
        points += _value;
        uiHandler.UpdatePoints(points);
    }

    public void AddPowerUp()
    {
        int randomPowerUp = Random.Range(0, powerUps.Count);
        //show powerUp on TowerUI
        //powerUps[randomPowerUp].powerUpScript.Read(powerUps[randomPowerUp].powerUpDescription);
        StartCoroutine(powerUps[randomPowerUp].powerUpScript.Action(GetComponent<Tower>()));
    }

    private IEnumerable EightBullets()
    {
        yield return null;
    }

    private IEnumerable UniversalBullet()
    {
        yield return null;
    }

    private IEnumerable Regeneration()
    {
        yield return null;
    }
}
