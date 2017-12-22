using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public Transform theBulletBeginPointUp;

    private GameObject theBullet;
    public GameObject theBulletRight;
    public GameObject theBulletLeft;
    public GameObject theBulletUp;
    public GameObject theBulletDown;

    public bool bulletShot;

    private BulletManager theBulletManagerScript;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ShootRight()
    {
        GameObject theGameObject = (GameObject)Instantiate(theBulletRight, transform.position, Quaternion.identity);
        theGameObject.GetComponent<BulletManager>().xTravelSpeed = 0.25f;
        theGameObject.GetComponent<BulletManager>().yTravelSpeed = 0f;
    }

    public void ShootLeft()
    {
        GameObject theGameObject = (GameObject)Instantiate(theBulletLeft, transform.position, Quaternion.identity);
        theGameObject.GetComponent<BulletManager>().xTravelSpeed = -0.25f;
        theGameObject.GetComponent<BulletManager>().yTravelSpeed = 0f;
    }

    public void ShootUp()
    {
        GameObject theGameObject = (GameObject)Instantiate(theBulletUp, transform.position, Quaternion.identity);
        theGameObject.GetComponent<BulletManager>().yTravelSpeed = 0.25f;
        theGameObject.GetComponent<BulletManager>().xTravelSpeed = 0f;
    }

    public void ShootDown()
    {
        GameObject theGameObject = (GameObject)Instantiate(theBulletDown, transform.position, Quaternion.identity);
        theGameObject.GetComponent<BulletManager>().yTravelSpeed = -0.25f;
        theGameObject.GetComponent<BulletManager>().xTravelSpeed = 0f;
    }
}
