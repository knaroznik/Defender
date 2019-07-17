using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Path path;
    public int Damage;
    public float movementSpeed;
    public float rotationSpeed;

    public ObjectType characterType;

    private int currentPointID = 0;

    private bool _moveEnabled = true;

    private void Start()
    {
        this.transform.position = path.GetPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_moveEnabled)
        {
            return;
        }
        float distance = Vector3.Distance(path.GetPosition(currentPointID), transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path.GetPosition(currentPointID), Time.deltaTime * movementSpeed);

        var rotation = Quaternion.LookRotation(path.GetPosition(currentPointID) - this.transform.position) * Quaternion.Euler(0, -90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);


        if(distance <= 1)
        {
            currentPointID++;
        }

        if(currentPointID >= path.Length())
        {
            _moveEnabled = false;

            path.playerHealth.Damage(Damage);
            Destroy(this.gameObject);
        }
    }
}
