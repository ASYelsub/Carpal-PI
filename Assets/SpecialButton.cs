using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialButton : Button
{
    public CourtRecordManager courtRecordManager;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //print("Clicked");
        courtRecordManager = FindObjectOfType<CourtRecordManager>();

        if(courtRecordManager == null)
        {
            print("FUCK");
        }
        else
        {
            courtRecordManager.DisplayClickedOnEvidence();
        }
        
    }
}

