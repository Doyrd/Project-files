using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour
{

    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;

	void Start()
    {
        pooledObjects = new List<GameObject>();
        
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject theObject = (GameObject)Instantiate(pooledObject);
            theObject.SetActive(false);
            pooledObjects.Add(theObject);
        }
	}

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject theObject = (GameObject)Instantiate(pooledObject);
        theObject.SetActive(false);
        pooledObjects.Add(theObject);
        return theObject;
    }

}
