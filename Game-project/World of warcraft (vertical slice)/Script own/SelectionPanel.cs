using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanel : MonoBehaviour
{

    public GameObject theSelectionPanel;
    /*public GameObject theStartingItem;*/

    public Transform theSelectionPanelTransform;

    public Vector3 newPositionUp;
    public Vector3 newPositionDown;

    public float moveUpOrDown;
    public float transitionSpeed;

    void Start ()
    {
        theSelectionPanelTransform = theSelectionPanel.GetComponent<Transform>();
    }

    void Update()
    {
        /*Debug.Log(theSelectionPanel.transform.position);*/
    }

    public void SlideUp()
    {
        newPositionUp = new Vector3(0, -moveUpOrDown, 0);
        theSelectionPanelTransform.transform.position += newPositionUp;
    }

    public void SlideDown()
    {
        newPositionDown = new Vector3(0, moveUpOrDown, 0);
        theSelectionPanelTransform.transform.position += newPositionDown;
    }

    /*public void StartingPosition()
    {
    }*/

}
