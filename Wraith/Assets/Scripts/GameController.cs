using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyShip;
    public Vector2 spawnValues;
    public int shipCount;
    public float spawnWait;
    public float startWait;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        for ( int i = 0; i<shipCount; i++) 
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(enemyShip, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }



//        //Min value of area
//        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
//        //Max value of area
//        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
//        
//        //spawn enemy
        

    }
}
