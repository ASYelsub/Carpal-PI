using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CourtRecordManager : MonoBehaviour
{
    [SerializeField]
    private BaseCaseLogic activeCaseLogic;
    [HideInInspector]
    public List<LocationBase> locationsBeingDisplayed = new List<LocationBase>();

    [SerializeField]
    private GameObject headerPrefab;
    
    [HideInInspector]
    public List<GameObject> headers = new List<GameObject>();
    
    public void ActivateCourtRecord()
    {
        GetLocationsInCase();
    }

    void GetLocationsInCase()
    {
        for (int i = 0; i < activeCaseLogic.locationsInCase.Length; i++)
        {
            locationsBeingDisplayed.Add(activeCaseLogic.locationsInCase[i]);
            //print(locationsBeingDisplayed[i].locationName + "added to the list.");
        }
        DisplayHeaders();
    }

    void DisplayHeaders()
    {
        for (int i = 0; i < locationsBeingDisplayed.Count; i++)
        {
            Vector2 headerPos = new Vector2(-210, 115 + i*20);
            headers.Add(headerPrefab);
        }
    }
    
}
