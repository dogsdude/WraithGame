using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyShip;
    public Vector2 spawnValues;

    private void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
        Quaternion spawnRotation = Quaternion.identity;
            
        Instantiate(enemyShip, spawnPosition, spawnRotation);

//        //Min value of area
//        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
//        //Max value of area
//        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
//        
//        //spawn enemy
        

    }
}
