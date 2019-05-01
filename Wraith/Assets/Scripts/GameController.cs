using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //The thing that will be spawned
    public GameObject enemyShip;
    
    //Where the thing will spawn
    public Vector2 spawnValues;
    
    //How many ships will spawn in the wave
    public int shipCount;
    
    //How long to wait in between ships
    public float spawnWait;
    
   //How long to wait before starting to spawn... Give player time to get ready for game to start (Maybe START! screen here)
    public float startWait;

    //How long to wait in between waves of ships (THIS WILL CHANGE ONCE I HAVE MULTIPLE WAVES OF DIFFERENT THINGS!)
    public float waveWait;
    
    //Background music for the game
    public AudioSource music;
    
    private void Start()
    {
        
        StartCoroutine(SpawnWaves());
        music.Play();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < shipCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(enemyShip, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

        }



//        //Min value of area
//        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
//        //Max value of area
//        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
//        
//        //spawn enemy
        

    }
}
