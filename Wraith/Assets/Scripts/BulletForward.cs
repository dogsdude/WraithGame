using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward: MonoBehaviour
{
    //The speed of our bullet
    public float maxSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        //Makes the bullet move
     Vector3 velocity = new Vector3
     (
         0,
         maxSpeed * Time.deltaTime,
         0
         );
     position += transform.rotation * velocity;

     transform.position = position;
    }
}
