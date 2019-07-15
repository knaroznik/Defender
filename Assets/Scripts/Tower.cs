using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    private float reloadTime = 0.4f;
    private float currentReloadTime = 0;

    // Update is called once per frame
    void Update()
    {
        Rotate();

        if (Input.GetMouseButton(0) && currentReloadTime <= 0)
        {
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
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
