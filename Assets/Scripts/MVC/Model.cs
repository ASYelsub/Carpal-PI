using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("Other Scripts")] 
    public View view;
    public Controller controller;
    public TextTyper TextTyper;

    [SerializeField]
    private BaseCaseLogic[] cases;
    
    [HideInInspector]
    public BaseCaseLogic activeCase;

    public void SetActiveCase(int caseNumber)
    {
        cases[caseNumber].ActivateCase();
        activeCase = cases[caseNumber];
        CheckSequenceType(false);
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
                view.DisplayBanter(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.CrossExamine :
                view.DisplayCrossExamine(isAlreadyLoaded);
                break;
            case SequenceBase.SequenceType.ShowSomethingOnEvidence :
                view.DisplayShowSomethingOnEvidence(isAlreadyLoaded);
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
        }
        print(activeCase.activeSequence.mySequenceType);
    }

    public void TextProgress()
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
                view.DisplayBanter(true);   
            }
        }
    }

    public void AdvanceToNextSequence()
    {
        activeCase.talkID = 0;
        activeCase.activeSequenceNumber++;
        activeCase.activeSequence = activeCase.sequencesInCase[activeCase.activeSequenceNumber];
        CheckSequenceType(false);
    }
    
}
