using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EvidenceButton : Button
{
    public CrimeSceneManager crimeSceneManager;
    public int evidenceDiscussionID;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        crimeSceneManager = FindObjectOfType<CrimeSceneManager>();
        if (crimeSceneManager == null)
        {
            print("FUCK");
        }
        else
        {
            crimeSceneManager.LoadSequenceDependingOnClickedEvidence(evidenceDiscussionID);
            print(evidenceDiscussionID);
        }
    }
}
