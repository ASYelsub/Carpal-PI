using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//handles maneuvering scenes and sequences in case 1
public class Case1Logic : MonoBehaviour
{
    [HideInInspector]
    public static SequenceBase activeSequence;

    public SceneTextBase currentScene;
    
    public SequenceBase[] sequencesInCase;
    public int activeSequenceNumber;

    public TextManager textManager;
    private void Start()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        currentScene = activeSequence.sceneTextsInSequence[0];
    }
    
    public void Sequence0Logic()
    {
        
    }

    public void Sequence1Logic()
    {
        
    }

    public void Sequence2Logic()
    {
        if(currentScene == Case1Logic.activeSequence.sceneTextsInSequence[1] || currentScene == Case1Logic.activeSequence.sceneTextsInSequence[2])
        {
            currentScene = Case1Logic.activeSequence.sceneTextsInSequence[0];
            currentScene.talkID = currentScene.tempTalkID;
            textManager.UpdateDialogue();
        }
    }
    
}
