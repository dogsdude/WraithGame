using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMove : MonoBehaviour
{
    //TODO: Ships of different types should fire/stay in the screen differently
    //Speed of enemy ship
    public float speed; 
   

    // Update is called once per frame
    // This function moves the enemy ship from top to bottom of the script
    // at set "speed"... This should be able to work for any number of things that move across the screen
    void Update()
    {
        Vector2 position = transform.position;
        
        position = new Vector2(position.x,position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint((new Vector2(0, 0)));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}
