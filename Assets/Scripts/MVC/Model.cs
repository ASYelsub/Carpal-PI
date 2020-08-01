using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("Other Scripts")] 
    public View view;
    public Controller controller;
    public TextTyper TextTyper;
    public LivesManager livesManager;
    public CourtRecordManager courtRecordManager;
    public CrimeSceneManager crimeSceneManager;

    [SerializeField]
    private BaseCaseLogic[] cases;
    
    [HideInInspector]
    public BaseCaseLogic activeCase;

    [HideInInspector] public bool textProgressValid;
    [HideInInspector] public int sequenceProgressionStyle; //0 is linear,
                                                            //1 is map,
                                                            //2 is crime scene
                                              
    public void SetActiveCase(int caseNumber)
    {
        view.duringCase.SetActive(true);
        view.preCase.SetActive(false);
        cases[caseNumber].ActivateCase();
        activeCase = cases[caseNumber];
        CheckSequenceType(false);
        textProgressValid = false;
        sequenceProgressionStyle = 0;
        
        
        for (int i = 0; i < activeCase.locationsInCase.Length; i++)
        {
            for (int j = 0; j < activeCase.locationsInCase[i].evidenceAtLocation.Length; j++)
            {
                activeCase.locationsInCase[i].evidenceAtLocation[j].evidenceCollected = false;
                print(activeCase.locationsInCase[i].evidenceAtLocation[j].name + " is " + activeCase.locationsInCase[i].evidenceAtLocation[j].evidenceCollected);
            }
        }
        courtRecordManager.ResetEvidenceState();
    }

    //This function looks at the sequence type of the
    //first sequence in the active case and then
    //w the view displays
    //what is needed for the sequence accordingly.
    
    //the boolean helps decide if everything needs to be
    //set visible according to the sequence type
    //or not.
    public void CheckSequenceType(bool isAlreadyLoaded)
    {
        print("check sequence type");
        switch (activeCase.activeSequence.mySequenceType)
        {
            case SequenceBase.SequenceType.Banter :
                view.DisplayBanter(isAlreadyLoaded, 0);
                break;
            case SequenceBase.SequenceType.CrossExamine :
                view.DisplayCrossExamine(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.ExplainEvidence :
                view.DisplayExplainEvidence(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.InvestigateItem :
                view.DisplayInvestigateItem(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.InterrogateWitness :
                view.DisplayInterrogateWitness(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.Return :
                view.DisplayReturn(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.Map :
                view.DisplayMap(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.SurveyCrimeScene :
                view.DisplaySurveyCrimeScene(isAlreadyLoaded, 0);
                break;
        }
        print(activeCase.activeSequence.mySequenceType);
    }

    //LOGIC TO BE PROGRAMMED IN
    //called when pressing f, unable to do this with investigateitem. different logic is called for the other kinds.
    //for banter, the text goes through until the end of the sequence and then does AdvanceToNextSequence.
    //for crossexamine, the text filters through and loops until the information integer has been appeased,
    //and then AdvanceToNextSequence is called
    //for showsomethingonevidence, the player clicks a correct spot on an image and then AdvanceToNextSequence is
    //called
    //for investigateItem, the player clicks somewhere on the background to trigger an item to be investigated,
    //this triggers the banter sequence associated with that evidence to be shown... (this one needs to be
    //thought out a bit more, it may be the death of linearly progressing sequences or AdvanceToNextSequence()
    //not being on BaseCaseLogic and be like AdvanceToNextSequence(SequenceInt) where SequenceInt has important
    //shit it does on BaseCaseObject.
    //For Return... I forget the difference between this and Banter. OOPS
    public void TextProgressBanter()
    {
        if (TextTyper.IsTyping())
        {
            TextTyper.QuickSkip();
        }
        else
        {
            if (activeCase.talkID >= activeCase.activeSequence.dialogueBitsInSequence.Length - 1)
            {
                AdvanceToNextSequence();
            }
            else
            {
                activeCase.talkID++;
                view.DisplayBanter(true, 0);   
            }
        }
    }

    public void TextProgressInterrogateWitness()
    {
        if (TextTyper.IsTyping())
        {
            TextTyper.QuickSkip();
        }
        else
        {
            if (activeCase.talkID >= activeCase.activeSequence.dialogueBitsInSequence.Length - 1)
            {
                //print("pointer in location value = " + controller.pointerInLocationValue);
                activeCase.locationsInCase[controller.pointerInLocationValue].evidenceAtLocation[crimeSceneManager.tempInt].evidenceCollected = true;
                courtRecordManager.ResetEvidenceState();
                GoToSurveySequence();
            }
            else
            {
                activeCase.talkID++;
                view.DisplayInterrogateWitness(true);  
            }
        }
    }

    public void TextProgressInvestigateItem()
    {
        if (TextTyper.IsTyping())
        {
            TextTyper.QuickSkip();
        }
        else
        {
            if (activeCase.talkID >= activeCase.activeSequence.dialogueBitsInSequence.Length - 1)
            {
                //print("pointer in location value = " + controller.pointerInLocationValue);
                activeCase.locationsInCase[controller.pointerInLocationValue].evidenceAtLocation[crimeSceneManager.tempInt].evidenceCollected = true;
                courtRecordManager.ResetEvidenceState();
                crimeSceneManager.DesaturateCollectedEvidence();
                GoToSurveySequence();
            }
            else
            {
                activeCase.talkID++;
                view.DisplayInvestigateItem(true);   
            }
        }
    }

    public void MapLoadLocation(int mapBeingClickedOn)
    {
        sequenceProgressionStyle = 1;
        StartSpecialSequence();
    }
    
    public void TextProgressExplainEvidence()
    {
        if (TextTyper.IsTyping())
        {
            TextTyper.QuickSkip();
        }
        else
        {
            if (activeCase.talkID >= activeCase.activeSequence.dialogueBitsInSequence.Length - 1)
            {
                //a test to see if i could change stuff to be displayed while a sequence progresses
                //activeCase.locationsInCase[0].evidenceAtLocation[0].evidenceCollected = !activeCase.locationsInCase[0].evidenceAtLocation[0].evidenceCollected;
                //courtRecordManager.ResetEvidenceState(); //this can only be done when courtRecordManager is active
                print("apparently this code happened");
                if (textProgressValid)
                {
                    AdvanceToNextSequence();
                }
            }
            else
            {
                view.DisplayExplainEvidence(true);
            }
        }
    }

    public void StartSpecialSequence()
    {
        sequenceProgressionStyle = 1;
        activeCase.talkID = 0;
        activeCase.revolvingSequenceNumber = 0;
        activeCase.activeSequence = activeCase.EvidenceGatheringSequences[controller.pointerInLocationValue]
            .entranceSeqencesAtLocation[activeCase.revolvingSequenceNumber];
        CheckSequenceType(false);
    }

    public void GoToSurveySequence()
    {
        activeCase.talkID = 0;
        activeCase.activeSequence = activeCase.EvidenceGatheringSequences[controller.pointerInLocationValue]
            .entranceSeqencesAtLocation[activeCase.revolvingSequenceNumber];
        CheckSequenceType(false);
    }
    public void AdvanceToNextSequence()
    {
        if (sequenceProgressionStyle == 0)
        {
            activeCase.talkID = 0;
            activeCase.activeSequenceNumber++;
            activeCase.activeSequence = activeCase.sequencesInCase[activeCase.activeSequenceNumber];
            CheckSequenceType(false);
        }
        else if (sequenceProgressionStyle == 1)
        {
            activeCase.talkID = 0;
            activeCase.revolvingSequenceNumber++;
            activeCase.activeSequence = activeCase.EvidenceGatheringSequences[controller.pointerInLocationValue]
                .entranceSeqencesAtLocation[activeCase.revolvingSequenceNumber];
            CheckSequenceType(false);
        }
        else if (sequenceProgressionStyle == 2)
        {
            activeCase.talkID = 0;
            activeCase.activeSequence = activeCase.EvidenceGatheringSequences[controller.pointerInLocationValue]
                .evidenceSequencesAtLocation[crimeSceneManager.tempInt];
            CheckSequenceType(false);
        }
    }


    
    
    //unfinished

    //This code is currently copying banter, it needs to be able to loop around on itself,
    //switch out dialoguebits when stop and the correct evidence are used, and then progress
    //to the next sequence when all the dialogueBits are in their ultimate "discovered" state.
    public void TextProgressCrossExamine()
    {
        if (TextTyper.IsTyping())
        {
            TextTyper.QuickSkip();
        }
        else
        {
            if (activeCase.talkID >= activeCase.activeSequence.dialogueBitsInSequence.Length - 1)
            {
                activeCase.talkID = 0;
                view.DisplayCrossExamine( true);
            }
            else
            {
                activeCase.talkID++;
                view.DisplayCrossExamine(true);  
            }
        }
    }
    public void TextBackCrossExamine()
    {
        if (TextTyper.IsTyping())
        {
            TextTyper.QuickSkip();
        }
        else
        {
            if (activeCase.talkID <= 0)
            {
                activeCase.talkID = activeCase.activeSequence.dialogueBitsInSequence.Length - 1;
                view.DisplayCrossExamine(true);
            }
            else
            {
                activeCase.talkID--;
                view.DisplayCrossExamine(true);  
            }
        }
    }

    
    
    
    
}
