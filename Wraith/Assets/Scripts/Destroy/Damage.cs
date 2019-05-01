using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //Ship health (Change to lives later?)
    public int hitpoints = 2;
    //Moment of invisibility when hit
    public float invizAmount = 0;
    private float invisibleTime = 0;
    //Keeps track of if we are invisible
    private int correctLayer;
    
    //When hit do this...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        
        Debug.Log("Trigger!");

        
        if (invisibleTime <= 0)
        {
            hitpoints--;
            invisibleTime = invizAmount;
            gameObject.layer = 10;

        }
    }

    void Start()
    {
        correctLayer = gameObject.layer;
    }
    

    //Death
    void Update()
    {
        invisibleTime -= Time.deltaTime;
        if (invisibleTime <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (hitpoints <= 0)
        {
            Die();
        }
    }

    //Death
    void Die()
    {
        
        Destroy(gameObject);
    }
}
