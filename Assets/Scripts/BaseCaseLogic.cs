using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//handles maneuvering scenes and sequences in case 1
public class BaseCaseLogic : MonoBehaviour
{
    [HideInInspector]
    public SequenceBase activeSequence;

    //public SceneTextBase currentScene;
    public SequenceBase[] sequencesInCase;
    public int activeSequenceNumber;
    public UIDisplay uiDisplay;
    [HideInInspector] public int talkID;
    [HideInInspector] public int tempTalkID;
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        activeSequence = sequencesInCase[0];
        talkID = 0;
        uiDisplay.LoadText();
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
            uiDisplay.UpdateDialogue();
        }
    }

    

    public void AdvanceSequence()
    {
        activeSequenceNumber++;
        activeSequence = sequencesInCase[activeSequenceNumber];
        uiDisplay.UpdateDialogue();
    }
    
}
