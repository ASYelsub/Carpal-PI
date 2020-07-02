using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2Logic : BaseCaseLogic
{
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        activeSceneTextNumber = 0; //starting on first dialouge
        
        activeSequence = sequencesInCase[0];
        activeSceneText = activeSequence.sceneTextsInSequence[0];
        talkID = 0;
        textManager.LoadText();
        //textTyper.Activate();
    }
    
    public void AdvanceDialogueBit()
    {
        if (talkID >= activeSceneText.dialogueBits.Length - 1)
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
        activeSceneTextNumber++;
        activeSceneText = activeSequence.sceneTextsInSequence[activeSceneTextNumber];
        textManager.UpdateDialogue();
    }
}
