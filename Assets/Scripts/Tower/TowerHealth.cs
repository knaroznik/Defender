using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    private int health = 100;
    private TowerUI uiHandler;

    private void Start()
    {
        uiHandler = GetComponent<TowerUI>();
    }

    public void Damage(int _value)
    {
        if (Alive())
        {
            health -= _value;
            if (health <= 0)
            {
                health = 0;
                Death();
            }
            uiHandler.UpdateHealth(health);
        }
    }

    public bool Alive()
    {
        return health > 0;
    }

    private void Death()
    {
        StartCoroutine(EDeath());
    }

    private IEnumerator EDeath()
    {
        yield return LoadingScreen.main.ChangeColor(Color.black);
        PauzeMenu.main.DeathUIObject.SetActive(true);
    }
}
