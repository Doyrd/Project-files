using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{

    public List<GameObject> theItemList;

    private int selectionIndex = 0;

    public Text theIndexNumber;

    public int indexDown;
    public int indexUp;

    public GameObject theUpButton1;
    public GameObject theUpButton2;
    public GameObject theDownButton1;
    public GameObject theDownButton2;

    public int theItemListCount;

    private bool indexDownBool;
    private bool indexUpBool;

    public SelectionPanel theSelectionPanelScript;

    void Start ()
    {

        theItemList = new List<GameObject>();

        foreach (Transform t in transform)
        {
            theItemList.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        theItemList[selectionIndex].SetActive(true);

    }
	
	void Update ()
    {

        theIndexNumber.text = "" + (selectionIndex + 1);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switchBetweenItemsDown();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switchBetweenItemsUp();
        }

        indexDown = selectionIndex;
        indexUp = selectionIndex;

        if (indexDown >= (theItemList.Count - 1))
        {
            theDownButton1.SetActive(false);
            theDownButton2.SetActive(true);
        }
        else if (indexDown < theItemList.Count)
        {
            theDownButton1.SetActive(true);
            theDownButton2.SetActive(false);
        }

        if (indexUp <= 0)
        {
            theUpButton1.SetActive(false);
            theUpButton2.SetActive(true);
            return;
        }
        else if (indexUp > 0)
        {
            theUpButton1.SetActive(true);
            theUpButton2.SetActive(false);
        }

        theItemListCount = theItemList.Count;

    }

    public void SelectItem(int index)
    {

        if(index == selectionIndex)
        {
            return;
        }

        if(index < 0 || index >= theItemList.Count)
        {
            return;
        }

        theItemList[selectionIndex].SetActive(false);
        selectionIndex = index;
        theItemList[selectionIndex].SetActive(true);

    }

    public void switchBetweenItemsDown()
    {
        if (indexDown >= theItemList.Count - 1)
        {
            return;
        }
        else
        {
            indexDown = selectionIndex + 1;
            theItemList[selectionIndex].SetActive(false);
            selectionIndex = indexDown;
            theItemList[selectionIndex].SetActive(true);
            theSelectionPanelScript.SlideDown();
        }

    }

    public void switchBetweenItemsUp()
    {
        if (indexUp < 1)
        {
            return;
        }
        else
        {
            indexUp = selectionIndex - 1;
            theItemList[selectionIndex].SetActive(false);
            selectionIndex = indexUp;
            theItemList[selectionIndex].SetActive(true);
            theSelectionPanelScript.SlideUp();
        }
    }



}
