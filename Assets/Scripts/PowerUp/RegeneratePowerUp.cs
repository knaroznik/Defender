using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneratePowerUp : PowerUpBase
{
    public override IEnumerator Action(Tower player)
    {
        player.GetComponent<TowerHealth>().Regenerate = true;
        yield return new WaitForSeconds(4f);
        player.GetComponent<TowerHealth>().Regenerate = false;
    }
}
