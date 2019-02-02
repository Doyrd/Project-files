using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour
{

    public float speed;

    private Renderer theRenderer;

	void Start ()
    {
        theRenderer = GetComponent<Renderer>();
	}
	
	void Update ()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        theRenderer.material.mainTextureOffset = offset;
	}

}
