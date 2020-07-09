using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    [Header("Other Scripts")] 
    public Model model;
    public View view;
    
    
    public bool pointerInImageExamineEvidence;

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
            if(Input.GetKeyDown(KeyCode.F))
            {
                print(" f pressed");
                if (model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.Banter)
                {
                    model.TextProgressBanter();
                }
                else if(model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.CrossExamine)
                {
                    model.TextProgressCrossExamine();
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.ExplainEvidence)
                {
                    if (pointerInImageExamineEvidence)
                    {
                        model.textProgressValid = true; 
                        model.TextProgressExplainEvidence();
                    }
                    else if (!pointerInImageExamineEvidence)
                    {
                        model.livesManager.LoseOneLife();
                    }   
                }
            }
            /*else if (Input.GetKeyDown(KeyCode.F) &&
                     model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.ExplainEvidence)
            {
                
            }*/
        }
    }
    public void PointerInButton(bool pointerEnters)
    {
        print("pointerInbutton = " + pointerEnters);
         pointerInImageExamineEvidence = pointerEnters;
    }

     public void StopDuringCrossExamine()
     {
         if (!view.courtRecordIsActive)
         {
             if (model.activeCase.activeSequence.mySequenceType == SequenceBase.SequenceType.CrossExamine)
             {
                 print("This happened.");
                 view.ToggleCourtRecord();
             }
             else
             {
                 print("stop pressed during incompatible sequenceType");
             }
         }
     }
    public void CycleCourtRecordDisplay(int leftRight) //left is 0 right is 1
 {
     switch (leftRight)
     { 
         case 0 :
             if (model.evidenceBeingShown <= 0)
             {
                 model.evidenceBeingShown = 3;
             }
             model.evidenceBeingShown--;
             model.DisplayEvidenceCourtRecord();
             break;
         case 1 :
             if (model.evidenceBeingShown >= 2)
             {
                 model.evidenceBeingShown = 0;
             }
             else
             {
                 model.evidenceBeingShown++;   
             }
             model.DisplayEvidenceCourtRecord();
             break;
     }
     //print("model.evidencebeingShown: " + model.evidenceBeingShown);
 }
}
