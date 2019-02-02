using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;
    public Text motivationText;

    public float scoreCount;
    public float highscoreCount;
    public float motivationCount;

    public float pointPerSecond;

    public float timeToWait;

    public bool scoreIncreasing;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreCount = PlayerPrefs.GetFloat("Highscore");
        }

        motivationText.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointPerSecond * Time.deltaTime;
        }

        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore", highscoreCount);
        }

        if (scoreCount >= 10)
        {
            motivationCount = 10;
            motivationText.enabled = true;
            TimerForMotivation();
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highscoreText.text = "Highscore: " + Mathf.Round(highscoreCount);
        motivationText.text = "You have reached " + Mathf.Round(motivationCount) + ", keep going!";
    }

    public void AddPoints(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }

    IEnumerator TimerForMotivation()
    {
        yield return new WaitForSeconds(5);
        motivationText.enabled = false;
    }

}
