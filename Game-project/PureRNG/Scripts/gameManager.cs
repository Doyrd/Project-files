using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public Transform platformGenerator;
    public Transform waterGenerator;

    private Vector3 platformStartPoint;
    private Vector3 waterStartPoint;

    public playerManager thePlayer;
    private Vector3 playerStartPoint;

    private objectDestroyer[] platformList;
    private objectDestroyer[] waterList;

    private scoreManager theScoreManager;

    public deathMenu theDeathMenu;

    public GameObject thePauseButton;

    public scrollingBackground theScrollingBackgroundScript;

    void Start()
    {
        platformStartPoint = platformGenerator.position;
        waterStartPoint = waterGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<scoreManager>();
	}
	
	void Update()
    {
	}

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        thePauseButton.SetActive(false);
        theDeathMenu.gameObject.SetActive(true);

        /*StartCoroutine("RestartGameRoutine");*/

        /*theScrollingBackgroundScript.speed = 1.0f;*/
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);
        thePauseButton.SetActive(true);

        platformList = FindObjectsOfType<objectDestroyer>();
        waterList = FindObjectsOfType<objectDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < waterList.Length; i++)
        {
            waterList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        waterGenerator.position = waterStartPoint;

        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        theScrollingBackgroundScript.speed = 0.1f;
    }

    /*public IEnumerator RestartGameRoutine()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<platformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;

        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
