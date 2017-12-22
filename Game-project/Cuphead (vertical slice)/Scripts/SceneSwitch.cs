using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
    }

    public AudioSource buttonSound;

    public void OnRestart()
    {
        Application.LoadLevel("Main scene");
        /*buttonSound.Play();*/
    }

    public void OnSwitch(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void QuitGame()
    {
        Application.Quit();
        /*buttonSound.Play();*/
    }

}