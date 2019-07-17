using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public BulletBase bulletType;

    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = bulletType.GetColor();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + this.transform.forward, Time.deltaTime * speed);

        //TODO : if to far destroy
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            ObjectType t = other.GetComponent<Character>().characterType;
            if(t == bulletType.GetBulletType())
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
