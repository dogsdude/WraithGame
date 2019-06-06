using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnMenu : MonoBehaviour
{
    public string menu;
    // Start is called before the first frame update
    public AudioSource creditsaudio;
    void Start()
    {
        creditsaudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menu);
        }
    }
}
