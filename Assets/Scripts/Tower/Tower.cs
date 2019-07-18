using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    private float reloadTime = 0.4f;
    private float currentReloadTime = 0;

    private BulletBase bulletType = new WhiteBullet();

    //MOVE TO ANOTHER CLASS
    public List<Text> texts;

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Shoot();

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            bulletType = new WhiteBullet();
            Bolden(0);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletType = new GreenBullet();
            Bolden(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            bulletType = new RedBullet();
            Bolden(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bulletType = new BlueBullet();
            Bolden(3);
        }

    }

    private void Bolden(int _value)
    {
        for(int i=0; i<texts.Count; i++)
        {
            if(i == _value)
            {
                texts[i].fontStyle = FontStyle.Bold;
            }
            else
            {
                texts[i].fontStyle = FontStyle.Normal;
            }
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && currentReloadTime <= 0)
        {
            GameObject x = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            x.GetComponent<Bullet>().bulletType = bulletType;
            currentReloadTime = reloadTime;
        }
        else
        {
            currentReloadTime -= Time.deltaTime;
        }
    }

    void Rotate()
    {
        Vector3 mouseWorldPosition = -Vector3.one;

        Plane plane = new Plane(Vector3.up, 0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            mouseWorldPosition = ray.GetPoint(distance);
            this.gameObject.transform.LookAt(mouseWorldPosition);
        }
    }
}
