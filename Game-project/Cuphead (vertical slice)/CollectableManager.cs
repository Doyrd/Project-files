using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{

    private Animator theAnimator;

    public GameObject theCoinBackground;

	void Start ()
    {
        theAnimator = GetComponent<Animator>();
	}
	
	void Update ()
    {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(CoinFinished(0.75f));
            theCoinBackground.SetActive(false);
            theAnimator.SetBool("Is picked up", true);
            /*gameObject.SetActive(false);*/
        }
    }

    IEnumerator CoinFinished(float theTimeToWait)
    {
        yield return new WaitForSeconds(theTimeToWait);
        gameObject.SetActive(false);
    }
}
