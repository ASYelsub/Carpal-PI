using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Intent: To spawn in all the evidence in the crime scene depending on the activesequence.activelocationbase
public class CrimeSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject clickableEvidencePrefab;

    [SerializeField] private GameObject background;

    public int tempInt;
    [Header("Other Scripts")]
    [SerializeField] private Model model;
    [SerializeField] private View view;
    [SerializeField] private Controller controller;
    [SerializeField] private CourtRecordManager courtRecordManager;
    
    public void DisplayEvidenceAtLocation()
    {
        List<Evidence> evidenceDisplayedAtLocation = new List<Evidence>();
        List<GameObject> gameObjectsAssociatedWithEvidence = new List<GameObject>();
        for (int i = 0; i < model.activeCase.activeSequence.sequenceLocation.evidenceAtLocation.Length; i++)
        {
             evidenceDisplayedAtLocation.Add(model.activeCase.activeSequence.sequenceLocation.evidenceAtLocation[i]);
             //print(evidenceDisplayedAtLocation[i]);
             GameObject activeEvidence = Instantiate(clickableEvidencePrefab, background.transform, false);
             activeEvidence.GetComponent<RectTransform>().anchoredPosition = evidenceDisplayedAtLocation[i].evidencePositionAtCrimeScene;
             activeEvidence.GetComponent<Image>().sprite = evidenceDisplayedAtLocation[i].imageInCrimeScene;
             activeEvidence.GetComponent<EvidenceButton>().evidenceDiscussionID = i;
             gameObjectsAssociatedWithEvidence.Add(activeEvidence);
        }
    }

    public void LoadSequenceDependingOnClickedEvidence(int loadSequenceNumber)
    {
        tempInt = loadSequenceNumber;
        if (model.activeCase.locationsInCase[controller.pointerInLocationValue]
            .evidenceAtLocation[tempInt].evidenceCollected == false)
        {
            model.sequenceProgressionStyle = 2;
            model.AdvanceToNextSequence();
        }
        else
        {
            print("This evidence has already been collected!");
        }
        
    }
   // public void AddEvidenceToCourtRecord(int evidenceID)
    //{
    //    courtRecordManager.ResetEvidenceState();
   // }

    public void DesaturateCollectedEvidence()
    {
        
    }

    
}
