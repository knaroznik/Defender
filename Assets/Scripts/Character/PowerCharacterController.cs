using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCharacterController : BaseCharacterController
{
    public override void Die(Path path, int points)
    {
        base.Die(path, points);
        path.playerPoints.AddPowerUp();
    }

    public override void SetUp(GameObject characterGameObject)
    {
        characterGameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
