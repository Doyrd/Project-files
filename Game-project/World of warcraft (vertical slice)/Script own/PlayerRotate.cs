using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotationSpeed = 150;

    public GameObject thePlayerModel;
    
    public Transform thePlayerTransform;

    public bool isRotating;

    public Quaternion theModelRotation = Quaternion.identity;

    void Start ()
    {
        thePlayerTransform = GetComponent<Transform>();
}

	void Update ()
    {
        theModelRotation.eulerAngles = thePlayerTransform.eulerAngles;
        if(rotationSpeed > 150)
        {
            rotationSpeed = 150;
        }
    }

    public void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector2.down, rotationX);
        /*transform.RotateAround(Vector3.down, rotationX);*/
    }

    public void OnButtonPressedRight()
    {
        print("Right button has been pressed.");
        /*thePlayerTransform = thePlayerModel.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0) * Time.deltaTime;*/
        thePlayerTransform = thePlayerModel.GetComponent<Transform>();
        thePlayerTransform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }

    public void OnButtonPressedLeft()
    {
        print("Left button has been pressed.");
        /*thePlayerTransform = thePlayerModel.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0) * Time.deltaTime;*/
        thePlayerTransform = thePlayerModel.GetComponent<Transform>();
        thePlayerTransform.Rotate(Vector3.down * -rotationSpeed * Time.deltaTime);

    }
}
