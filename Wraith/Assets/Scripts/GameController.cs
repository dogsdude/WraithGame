using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject baseEnemy;
    public Vector2 spawnValues;

    private void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
        Quaternion spawnRotation = new Quaternion();
            
        Instantiate(baseEnemy, spawnPosition, spawnRotation);
    }
}
