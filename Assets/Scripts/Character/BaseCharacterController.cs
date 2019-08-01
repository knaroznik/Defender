using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController
{
    public virtual void Die(Path path, int points)
    {
        path.playerPoints.AddPoints(points);
    }

    public virtual void SetUp(GameObject characterGameObject)
    {
        characterGameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
