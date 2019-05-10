using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class GameController : MonoBehaviour
{
    //The thing that will be spawned
    public GameObject enemyShip;
    public GameObject meteor;
    
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
    public AudioSource sound;
    public AudioClip backgroundMusic;
    public AudioClip death;
    
    
    //Text to hold score
    public Text scoreText;
    private int score;

    //Text to hold restart and gameover
    public Text restartTxt;
    public Text gameOverTxt;

    //Bools to keep track of gameover versus restart logic
    private bool gameOver;
    private bool restart;
    
    
    private void Start()
    {
        //The game is not over, and has not been restarted
        gameOver = false;
        restart = false;

        //Empty strings at the start of the game
        restartTxt.text = "";
        gameOverTxt.text = "";
        
        //Score starts at 0 and is updated as game is played
        score = 0;
        UpdateScore();
        
        //This coroutine starts the waves of enemies
        StartCoroutine(SpawnWaves());
        
        //Plays my background music
        //sound.PlayOneShot(death);
        sound.clip = backgroundMusic;
        sound.Play();
    }

    private void Update()
    {
        //Restarts the game
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
    
    //This is a coroutine that infintely spawns waves of enemies... The hope is to get different kinds of enemies
    //to be randomly spawned in along with everything else to give everything some variety. Along with enemies that can
    //shoot at the player and powerups.
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

                if ( (i%3) == 0)
                {
                    Vector2 newSpawn = new Vector2(Random.Range(-spawnValues.x, spawnValues.x) - 1, spawnValues.y);
                    Instantiate(meteor, newSpawn, spawnRotation);
                }
                
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);


            //Ends the game
            if (gameOver)
            {
                restartTxt.text = "'R' to restart";
                restart = true;
                break;
            }

        }

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreVal)
    {
        score += newScoreVal;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverTxt.text = "Game Over!";
        gameOver = true;
        
        
        sound.Stop();
        //sound.loop = false;
        sound.clip = death;
        Invoke("playDeath", 1.0f);
        Debug.Log("Death played");
    }

   void playDeath()
    {
        sound.Play();
    }

   
}
