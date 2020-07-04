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
    [HideInInspector] public int talkID;
    [HideInInspector] public int tempTalkID;
    public int activeSequenceNumber;
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        activeSequence = sequencesInCase[0];
        talkID = 0;
    }



}
