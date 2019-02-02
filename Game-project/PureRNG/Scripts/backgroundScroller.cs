using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{

    public float speed = 0;

    public static backgroundScroller current;

    private float pos = 0;

    private Renderer theRenderer;


    void Start()
    {
        current = this;

        theRenderer = GetComponent<Renderer>();
    }

    public void Go()
    {
        pos += speed;
        if(pos > 1.0f)
        {
            pos -= 1.0f;
            theRenderer.material.mainTextureOffset = new Vector2(pos, 0);
        }
    }

}