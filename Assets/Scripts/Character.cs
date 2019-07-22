using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Path path;
    public int Damage;
    public int Points;
    public float movementSpeed;
    public float rotationSpeed;
    public float addspeed;

    private float accuracy;

    public ObjectType characterType;

    private int currentPointID = 0;


    private void Start()
    {
        accuracy = Random.Range(0f, 1f);
        this.transform.position = path.GetPosition(0);
    }

    public void SetUp(Path _path, int _damage, int _points, float _addSpeed)
    {
        path = _path;
        Damage = _damage;
        Points = _points;
        addspeed = _addSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(path.GetPosition(currentPointID), transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path.GetPosition(currentPointID), Time.deltaTime * (movementSpeed + addspeed));

        var rotation = Quaternion.LookRotation(path.GetPosition(currentPointID) - this.transform.position) * Quaternion.Euler(0, -90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);


        if(distance <= accuracy)
        {
            currentPointID++;
        }

        if(currentPointID >= path.Length())
        {
            path.playerHealth.Damage(Damage);
            Destroy(this.gameObject);
        }
    }

    public void Die()
    {
        path.playerPoints.AddPoints(Points);
    }
}
