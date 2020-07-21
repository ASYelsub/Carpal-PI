using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CourtRecordManager : MonoBehaviour
{
    [SerializeField]
    private BaseCaseLogic activeCaseLogic;
    
    [SerializeField]
    private GameObject headerPrefab;

    [SerializeField] 
    private GameObject evidenceIconPrefab;

    [SerializeField] 
    private GameObject evidenceBackgroundPrefab;

    [SerializeField] 
    private Evidence inactiveEvidence;
    
    [HideInInspector]
    public List<LocationBase> locationsBeingDisplayed = new List<LocationBase>();

    [HideInInspector]
    public List<GameObject> headers = new List<GameObject>();

    [HideInInspector]
    public List<GameObject> bigListOfEvidenceIcons = new List<GameObject>();
    
    [HideInInspector]
    public List<GameObject> bigListOfEvidenceBackgrounds = new List<GameObject>();
    
    [HideInInspector]
    public bool courtRecordActive = false;
    
    public void ActivateCourtRecord()
    {
        courtRecordActive = !courtRecordActive;
        GetLocationsInCase();
    }

    public void DeactivateCourtRecord()
    {
        print("deactivated, bitch");
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
            int k = 0;
            int l = 0;
            if (i >= 4 && locationsBeingDisplayed.Count > 4)
            {
                k = 100;
                l = i - 4;
            }
            else
            {
                k = 0;
                l = i;
            }
            Vector2 headerPos = new Vector2(-220 + k, 115 - l*80);
            GameObject activeHeaderPrefab = Instantiate(headerPrefab,gameObject.transform,false);
            activeHeaderPrefab.GetComponent<RectTransform>().anchoredPosition = headerPos;
            activeHeaderPrefab.GetComponentInChildren<Text>().text = locationsBeingDisplayed[i].locationName;
            headers.Add(activeHeaderPrefab);
            DisplayEvidenceUnderHeader(i);
        }
        print("headers:" + headers[0].GetComponentInChildren<Text>().text + headers[1].GetComponentInChildren<Text>().text + headers[2].GetComponentInChildren<Text>().text);
        //print("bigListOfEvidenceIcons has " + bigListOfEvidenceIcons.Count + " amount of shit in it.");
    }

    void DisplayEvidenceUnderHeader(int headerNumber)
    {
        for (int i = 0; i < locationsBeingDisplayed[headerNumber].evidenceAtLocation.Length; i++)
        {
            int h = 0;
            int k = 0;
            if (i >= 2 && locationsBeingDisplayed[headerNumber].evidenceAtLocation.Length > 2)
            {
                h = 25;
                k = i - 2;
            }
            else
            {
                h = 0;
                k = i;
            }
            Vector2 evidencePos = new Vector2(-25 + h,-25 - k * 25);
            GameObject activeEvidenceBackground = Instantiate(evidenceBackgroundPrefab, headers[headerNumber].transform, false);
            //bigListOfEvidenceBackgrounds.Add(activeEvidenceBackground);
            GameObject activeEvidenceIconPrefab = Instantiate(evidenceIconPrefab, headers[headerNumber].transform, false);
            //bigListOfEvidenceIcons.Add(activeEvidenceIconPrefab);
            activeEvidenceBackground.GetComponent<RectTransform>().anchoredPosition = evidencePos;
            activeEvidenceIconPrefab.GetComponent<RectTransform>().anchoredPosition = evidencePos;
            
            //* This is currently set in the scriptableObjcets of evidences, *//
            //* ideally it would be on the BaseCaseLogic. *//
            if (locationsBeingDisplayed[headerNumber].evidenceAtLocation[i].evidenceCollected)
            { 
                activeEvidenceIconPrefab.GetComponent<Image>().sprite = locationsBeingDisplayed[headerNumber].evidenceAtLocation[i].imageInCourtRecord;   
            }
            else
            {
                activeEvidenceIconPrefab.GetComponent<Image>().sprite = inactiveEvidence.imageInCourtRecord;
            }
        }
    }
}
