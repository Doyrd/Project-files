using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableGenerator : MonoBehaviour
{

    public objectPooler collectablePooler;

    public float distanceBetweenCollectables;

    public void spawnCollectables(Vector3 startPosition)
    {
        GameObject collectable1 = collectablePooler.GetPooledObject();
        collectable1.transform.position = startPosition;
        collectable1.SetActive(true);

        /*GameObject collectable2 = collectablePooler.GetPooledObject();
        collectable2.transform.position = new Vector3(startPosition.x - distanceBetweenCollectables, startPosition.y, startPosition.z);
        collectable2.SetActive(true);*/

        /*GameObject collectable3 = collectablePooler.GetPooledObject();
        collectable3.transform.position = new Vector3(startPosition.x + distanceBetweenCollectables, startPosition.y, startPosition.z);
        collectable3.SetActive(true);*/
    }

}
