using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreview : MonoBehaviour
{

    /*public Quaternion thePreviewModelRotation = Quaternion.identity;*/
    private Transform thePlayerTransform;

    public PlayerRotate thePlayerRotateScript;

	void Start ()
    {
        thePlayerTransform = GetComponent<Transform>();

        /*thePreviewModelRotation.eulerAngles = new Vector3(50, 50, 0);*/
        /*print(thePreviewModelRotation.eulerAngles.y);*/
    }
	
	void Update ()
    {
        /*thePlayerTransform.eulerAngles = new Vector3(thePreviewModelRotation.eulerAngles.x, transform.position.y, transform.position.z);*/
        thePlayerTransform.eulerAngles = thePlayerRotateScript.theModelRotation.eulerAngles;
    }

}
