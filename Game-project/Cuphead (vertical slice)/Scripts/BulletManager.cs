using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float xTravelSpeed;
    public float yTravelSpeed;
    public float damageValue;

    void Start ()
    {
        StartCoroutine(DestroyBulletsAfterTime(10));
	}
	
	void Update ()
    {
        Vector2 position = transform.position;
        position.x += xTravelSpeed;
        position.y += yTravelSpeed;
        transform.position = position;
	}

    //Destroying the bullet after certain time
    IEnumerator DestroyBulletsAfterTime(float timeLimit)
    {
        yield return new WaitForSeconds(timeLimit);
        Destroy(gameObject);
    }

}
