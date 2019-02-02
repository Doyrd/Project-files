using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class deathMenu : MonoBehaviour
{

    public GameObject thePauseButton;

    public AudioSource buttonSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        buttonSound.Play();
        FindObjectOfType<gameManager>().Reset();
    }

    public void QuitToMenu(int sceneToChangeTo)
    {
        buttonSound.Play();
        SceneManager.LoadScene(sceneToChangeTo);
        thePauseButton.SetActive(true);
    }

}
