using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ObjectPoolAble
{
    public float speed;
    private BulletBase bulletType;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + this.transform.forward, Time.deltaTime * speed);
    }

    public void SetType(BulletBase _type)
    {
        bulletType = _type;
        this.gameObject.GetComponent<Renderer>().material.color = bulletType.GetColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            ObjectType t = other.GetComponent<Character>().characterType;
            if(t == bulletType.GetBulletType())
            {
                other.GetComponent<Character>().Die();
                other.GetComponent<ObjectPoolAble>().Destroy();
            }
            Destroy();
        }
    }

    protected override void ResetObject()
    {
        base.ResetObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy();
    }
}
