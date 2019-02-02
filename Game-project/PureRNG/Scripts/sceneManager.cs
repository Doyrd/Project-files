using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneManager : MonoBehaviour
{

    public AudioSource buttonSound;

    public void changeSceneTo(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
        buttonSound.Play();
    }

    public void quitGame()
    {
        Application.Quit();
        buttonSound.Play();
    }

}
