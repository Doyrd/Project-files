using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableManager : MonoBehaviour
{

    public int pointsAdded;

    private scoreManager theScoreManager;

    private AudioSource collectableSound;

    void Start()
    {
        theScoreManager = FindObjectOfType<scoreManager>();
        collectableSound = GameObject.Find("Collectable sound effect").GetComponent<AudioSource>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            theScoreManager.AddPoints(pointsAdded);
            gameObject.SetActive(false);

            if (collectableSound.isPlaying)
            {
                collectableSound.Stop();
                collectableSound.Play();
            }
            else
            {
                collectableSound.Play();
            }
        }
    }

}
