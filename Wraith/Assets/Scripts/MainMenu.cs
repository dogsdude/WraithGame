using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioSource TitleMusic;
    public string newGameScene;
    // Start is called before the first frame update
    void Start()
    {
        TitleMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Options()
    {
        
    }
}
