using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    private int health = 100;
    private TowerUI uiHandler;
    public GameObject floatingText;
    public ObjectPool objectPool;
    public Transform canvas;

    private void Start()
    {
        objectPool.AddPrototype(floatingText);
        objectPool.AddParentObject(this.gameObject);
        uiHandler = GetComponent<TowerUI>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health = 0;
            Death();
        }
    }

    public void Damage(int _value)
    {
        if (Alive())
        {
            health -= _value;
            ShowDamage(_value);
            if (health <= 0)
            {
                health = 0;
                Death();
            }
            uiHandler.UpdateHealth(health);
        }
    }

    public void ShowDamage(int _value)
    {
        GameObject instance = objectPool.acquireReusable(floatingText);
        instance.transform.SetParent(canvas, false);
        instance.transform.SetAsFirstSibling();
        instance.GetComponent<FloatingText>().Start();
        instance.GetComponent<FloatingText>().SetText(_value.ToString());
        instance.GetComponent<FloatingText>().SetPosition(this.transform.position);
    }

    public bool Alive()
    {
        return health > 0;
    }

    private void Death()
    {
        PlaceData x = new PlaceData();
        x.placePoints = GetComponent<TowerPoints>().points;
        Leaderboard.main.TryInsert(x);
        StartCoroutine(EDeath());
    }

    private IEnumerator EDeath()
    {
        yield return LoadingScreen.main.ChangeColor(Color.black);
        PauzeMenu.main.DeathUIObject.SetActive(true);
    }
}
