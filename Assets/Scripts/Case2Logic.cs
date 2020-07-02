using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2Logic : BaseCaseLogic
{
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house

        activeSequence = sequencesInCase[0];
        talkID = 0;
        textManager.LoadText();
    }
    
    public void AdvanceDialogueBit()
    {
        if (talkID >= activeSequence.dialogueBitsInSequence.Length - 1)
        {
            talkID = 0;
            AdvanceSceneText();
        }
        else
        {
            talkID++;
            textManager.UpdateDialogue();
        }
    }

    public void AdvanceSceneText()
    {
        textManager.UpdateDialogue();
    }
}
