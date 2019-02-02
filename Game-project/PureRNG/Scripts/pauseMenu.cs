using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    public AudioSource buttonSound;

    public GameObject thePauseMenu;
    public GameObject theOptionsMenu;
    public GameObject thePauseButton;

    public bool paused = false; 
    
    void Update()
    {

        if (!paused && Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("You have paused the game.");
            paused = true;
            PauseGame();
        }
        else if (paused && Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("You have continued the game");
            paused = !paused;
            ResumeGame();
        }

    }

    public void PauseGame()
    {
        buttonSound.Play();
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
        thePauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
        thePauseButton.SetActive(true);
    }

    public void RestartGame()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        FindObjectOfType<gameManager>().Reset();
        thePauseMenu.SetActive(false);
        thePauseButton.SetActive(true);
    }

    public void QuitToMenu(int sceneToChangeTo)
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToChangeTo);
        thePauseButton.SetActive(true);
    }

    public void OptionsFromPauseMenu()
    {
        buttonSound.Play();
        thePauseMenu.SetActive(false);
        theOptionsMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void backToPauseMenu()
    {
        buttonSound.Play();
        thePauseMenu.SetActive(true);
        theOptionsMenu.SetActive(false);
        Time.timeScale = 0f;
    }

}

