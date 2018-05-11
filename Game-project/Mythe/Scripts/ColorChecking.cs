using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecking : MonoBehaviour
{

    /// <summary> This script is meant for checking color. </summary> ///

    [Header("String(s)")]
    public string ballColor;
    public string cloudColor;

    [Header("Component(s)")]
    private SpriteRenderer theSpriteRenderer;

    [Header("Game object(s)")]
    public GameObject theCloud;

    [Header("Script(s)")]
    private Projectile theProjectileScript;

    void Start ()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();

        theProjectileScript = FindObjectOfType<Projectile>();

        GetColorOfBall();   
    }
	
	void Update ()
    {
        CheckColorMatch();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        theCloud = GameObject.FindGameObjectWithTag("Cloud");

        if (other.gameObject.CompareTag("Cloud"))
        {
            cloudColor = theCloud.GetComponent<SpriteRenderer>().sprite.name;
        }
    }

    private void GetColorOfBall()
    {
        ballColor = theSpriteRenderer.sprite.name;
    }

    public void CheckColorMatch()
    {
        if(ballColor == cloudColor)
        {
            theProjectileScript.OnDeath();
        }
    }

}
