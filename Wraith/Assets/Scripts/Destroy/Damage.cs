using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //TODO: Fix invisible settings when player is hit... Need to differentiate player explosion versus enemy?
    //TODO: All of the layer stuff is currently broken or unused
    //TODO: Make sure player Hitpoints is visible on screen. Currently the player dies on hit

    //Ship health (Change to lives later?)
    public int hitpoints = 2;

    //Moment of invisibility when hit
    public float invizAmount = 0;
    private float invisibleTime = 0;

    //Keeps track of if we are invisible (THIS WILL BE IMPLEMENTED IN FULL LATER)
    private int correctLayer;

    //Explosion now instantiated when something dies
    public GameObject explode;

    private GameController gameController;

    public int scoreVal;

   
    //When hit do this...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Debug.Log("Trigger!");

        //Implement hitpoints here?
        if ((other.tag == "Player") )
        {
           
            Debug.Log("Player death");
            Instantiate(explode, transform.position, transform.rotation);
            gameController.GameOver();
            
            //gameController.sound.Stop();
        }
        Instantiate(explode, transform.position, transform.rotation);
        Debug.Log("Non-player explosion");

        gameController.AddScore(scoreVal);
        Destroy(other.gameObject);
        Destroy(gameObject);

//        if (invisibleTime <= 0)
//        {
//            hitpoints--;
//            invisibleTime = invizAmount;
//            gameObject.layer = 10;
//        }
    }

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }

        //correctLayer = gameObject.layer;
    }


//    //Death
//    void Update()
//    {
//        invisibleTime -= Time.deltaTime;
//        if (invisibleTime <= 0)
//        {
//            gameObject.layer = correctLayer;
//        }
//
//        if (hitpoints <= 0)
//        {
//            Die();
//        }
//    }
//
//    //Death
//    void Die()
//    {
//        //Instantiate(explosion, transform.position, transform.rotation);
//
//        gameController.AddScore(scoreVal);
//        Destroy(gameObject);
//        Instantiate(explode, transform.position, transform.rotation);
//    }
}