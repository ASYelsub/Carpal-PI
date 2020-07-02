using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case1Logic : BaseCaseLogic
{
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house

        activeSequence = sequencesInCase[0];
        talkID = 0;
        textManager.LoadText();
        //textTyper.Activate();
    }
    
    public void AdvanceDialogueBit()
    {
        if (talkID >= activeSequence.dialogueBitsInSequence.Length - 1)
        {
            talkID = 0;
            AdvanceSequence();
        }
        else
        {
            talkID++;
            textManager.UpdateDialogue();
        }
    }

    public void AdvanceSequence()
    {
        activeSequenceNumber++;
        activeSequence = sequencesInCase[activeSequenceNumber];
        textManager.UpdateDialogue();
    }
}
