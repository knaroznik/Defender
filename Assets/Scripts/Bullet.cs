using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

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
            //CHECK SHAPE TODO
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
