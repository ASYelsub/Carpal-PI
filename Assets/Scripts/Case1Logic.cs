using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//handles maneuvering scenes and sequences in case 1
public class Case1Logic : MonoBehaviour
{
    [HideInInspector]
    public SequenceBase activeSequence;
    [HideInInspector]
    public SceneTextBase activeSceneText;
    //public SceneTextBase currentScene;
    
    public SequenceBase[] sequencesInCase;
    public int activeSequenceNumber;
    public int activeSceneTextNumber;
    public TextManager textManager;
    [HideInInspector] public int talkID;
    [HideInInspector] public int tempTalkID;
    private void Awake()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        activeSceneTextNumber = 0; //starting on first dialouge
        
        activeSequence = sequencesInCase[0];
        activeSceneText = activeSequence.sceneTextsInSequence[0];
        talkID = 0;
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
