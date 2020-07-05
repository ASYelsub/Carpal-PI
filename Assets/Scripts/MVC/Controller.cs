﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Other Scripts")] 
    public Model model;
    public View view;

    //This function gets an integer from one of the two start buttons to set the activeCase.
    //1 is the first case. 2 is the second case.
    public void GetActiveCase(int caseNumber)
    {
        model.SetActiveCase(caseNumber);
    }
    private void Update()
    {
        if (!view.courtRecordIsActive)
        {
            if(Input.GetKeyDown(KeyCode.F) && 
               model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.Banter)
            {
                model.TextProgressBanter();
            }

            else if (Input.GetKeyDown(KeyCode.F) &&
                model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.CrossExamine)
            {
                model.TextProgressCrossExamine();
                print(" f pressed");
            }   
        }
    }

    public void CycleCourtRecordDisplay(int leftRight) //left is 0 right is 1
    {
        switch (leftRight)
        { 
            case 0 :
                model.MoveEvidenceToTheLeftCourtRecord();
                break;
            case 1 :
                model.MoveEvidenceToTheRightCourtRecord();
                break;
        }
        
    }
    public void StopDuringCrossExamine()
    {
        if (!view.courtRecordIsActive)
        {
            if (model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.CrossExamine)
            {
                print("This happened.");
                model.SetEvidenceRows();
            }
            else
            {
                print("stop pressed during incompatible sequenceType");
            }
        }
    }
}