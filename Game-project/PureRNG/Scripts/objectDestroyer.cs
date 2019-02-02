using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroyer : MonoBehaviour
{

    public GameObject platformDestroyPoint;

    void Start()
    {
        platformDestroyPoint = GameObject.Find("Platform destroy point");
    }

    void Update()
    {
        if(transform.position.x < platformDestroyPoint.transform.position.x)
        {
            /*Destroy(gameObject);*/
            gameObject.SetActive(false);
        }
    }

}
