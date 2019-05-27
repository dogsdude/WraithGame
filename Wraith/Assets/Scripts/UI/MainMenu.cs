using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioClip startSound;
    public AudioClip quitSound;
    public AudioClip optionSound;
    public AudioSource TitleSound;
    public string newGameScene;
    // Start is called before the first frame update

    public Animator animator;
   //plays title music
    void Start()
    {
        TitleSound.Play();
    }

   //This method actually fades into our scene
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Fade in
        FadeToLevel();
        
        //Play music
        TitleSound.clip = startSound;
        TitleSound.Play();
        
        //Start game
        StartCoroutine(OnFadeComplete());
    }

    IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(newGameScene);
    }

    public void Quit()
    {
        TitleSound.clip = quitSound;
        TitleSound.Play();
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Options()
    {
        TitleSound.clip = optionSound;
        TitleSound.Play();
       
    }
}
