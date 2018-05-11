using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadMechanic : MonoBehaviour
{
    /// <summary> This script is meant for the reloading mechanic, this is fixed version. </summary> ///

    [Header("List(s)")]
    [SerializeField]
    private List<GameObject> listOfProjectiles;
    [SerializeField]
    private List<GameObject> listOfPreviewSlots;

    [Header("Array(s)")]
    public GameObject[] savedPreviewSlots;
    private GameObject[] previewSlots;


    [Header("Int(s)")]
    private int i;
    private int j;
    private int k;
    private int a;
    private int b;

    [Header("Game object(s)")]
    public GameObject savedProjectile;
    private GameObject projectile;

    [Header("String(s)")]
    private string previewSlotColor;

	void Start ()
    {
        previewSlots = new GameObject[3];

        ProjectileFillAtStart(projectile, listOfProjectiles);
    
        PreviewSlotsFillAtStart(previewSlots, listOfPreviewSlots);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ReloadProcess();
        }
    }

    private void ProjectileFillAtStart(GameObject objectToFill, List<GameObject> listToChooseFrom)
    {
        i = Random.Range(0, listToChooseFrom.Count);
        objectToFill = listToChooseFrom[i];
        savedProjectile = Instantiate(objectToFill);
    }

    private void RemoveCurrentProjectile()
    {
        GameObject.Destroy(savedProjectile);
    }

    private void PreviewSlotsFillAtStart(GameObject[] arrayToFill, List<GameObject> listToChooseFrom)
    {
        for (a = 0; a <  arrayToFill.Length; a++)
        {
            j = Random.Range(0, listToChooseFrom.Count);
            arrayToFill[a] = listToChooseFrom[j];
            Instantiate(arrayToFill[a]);
            savedPreviewSlots = arrayToFill;
        }
    }

    private void RemoveCurrentFilledSlots()
    {
        for(b = 0; b < savedPreviewSlots.Length; b++)
        {
            GameObject.Destroy(savedPreviewSlots[b]);
        }
    }

    private void GetNewFillSlot(List<GameObject> listToChooseFrom)
    {
        k = Random.Range(0, listToChooseFrom.Count);
        savedPreviewSlots[2] = listToChooseFrom[k];
        Instantiate(savedPreviewSlots[2]);
    }

    private void NextProjectileInitialize(List<GameObject> listToChooseFrom)
    {
        // Delete preview slot one.


        /*savedProjectile = savedPreviewSlots[0];*/

        previewSlotColor = savedPreviewSlots[0].name;

        switch (previewSlotColor)
        {
            case "blauw":
                Instantiate(listOfPreviewSlots[0]);
                break;
            case "geel":
                Instantiate(listOfPreviewSlots[1]);
                break;
            case "rood":
                Instantiate(listOfPreviewSlots[2]);
                break;
            case "roze":
                Instantiate(listOfPreviewSlots[3]);
                break;
            default:
                Debug.Log("There is no color found.");
                break;
        }
    }
    
    public void ReloadProcess()
    {
        NextProjectileInitialize(listOfProjectiles);
        savedPreviewSlots[0] = savedPreviewSlots[1];
        savedPreviewSlots[1] = savedPreviewSlots[2];
        GetNewFillSlot(listOfPreviewSlots);
    }


    // Projectile = preview slot 1.
    // Projectile color = preview slot color.
    // Set preview slot array[0] into gameObject new projectile.
}
