using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
 
        public AudioClip startSound;
        public AudioClip quitSound;
        public AudioClip menuSound;
        public AudioSource pauseSounds;
        public string newGameScene;
        // Start is called before the first frame update

        public static bool GameIsPaused = false;
        public GameObject pauseMenu;
        public Animator animator;
        

        public void FadeToLevel()
        {
            animator.SetTrigger("FadeOut");
        }

        public void Menu()
        {
            //Fade in
            FadeToLevel();
        
            //Play music
            pauseSounds.clip = startSound;
            pauseSounds.Play();
        
            //Start game
            StartCoroutine(OnFadeComplete());
        }

        IEnumerator OnFadeComplete()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(newGameScene);
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            
        }

        void Pause()
        {
            
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        
        public void Quit()
        {
            pauseSounds.clip = quitSound;
            pauseSounds.Play();
            Debug.Log("Quit!");
            Application.Quit();
        }

        
    }
